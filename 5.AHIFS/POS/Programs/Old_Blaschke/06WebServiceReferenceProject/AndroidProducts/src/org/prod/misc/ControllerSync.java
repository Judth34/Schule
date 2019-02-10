package org.prod.misc;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.URL;
import java.net.URLConnection;

import android.os.AsyncTask;
import java.io.BufferedOutputStream;
import java.io.BufferedWriter;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;

public class ControllerSync extends AsyncTask<String, Void, String> {

    private static final String URI_2ND = "WebServerProducts/webresources/";
    private String url_1st;

    public ControllerSync(String url) throws Exception {
        this.url_1st = url;
    }

    @Override
    protected String doInBackground(String... command) {
        boolean isGet = true, isPut = false;

        BufferedReader reader = null;
        BufferedWriter writer = null;
        String content = null;
        URL url = null;

        try {
            if (command[0].equals("PRODUCERLIST")) {
                //call producerlist
                url = new URL(url_1st + URI_2ND + "ProducerList");
            } else if (command[0].equals("PRODUCTLIST")) {
                //call productlist
                url = new URL(url_1st + URI_2ND + "ProductList/");
            } else if (command[0].equals("PRODUCTDETAIL")) {
                //call productlist
                url = new URL(url_1st + URI_2ND + "ProductDetail/" + command[1]);
            } else if (command[0].equals("PRODUCTUPDATE")) {
                //call productdetail put
                url = new URL(url_1st + URI_2ND + "ProductDetail");
                isGet = false;
                isPut = true;
            }

            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            if (isPut) {
                conn.setRequestMethod("PUT");
                conn.setRequestProperty("Content-Type", "application/json");
                writer = new BufferedWriter(new OutputStreamWriter(conn.getOutputStream()));
                writer.write(command[1]); //product - object in json-format
                writer.flush();
                writer.close();
                conn.getResponseCode();
            }
            // get data from server
            reader = new BufferedReader(new InputStreamReader(
                    conn.getInputStream()));
            StringBuilder sb = new StringBuilder();
            String line = null;

            while ((line = reader.readLine()) != null) {
                sb.append(line);
            }

            content = sb.toString();
            reader.close();
            conn.disconnect();
        } catch (Exception ex) {
            content = "error in doInBackground: " + ex.getMessage();
        }
        return content;

    }

}
