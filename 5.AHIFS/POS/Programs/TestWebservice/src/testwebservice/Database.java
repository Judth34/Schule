/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package testwebservice;

import com.google.gson.Gson;
import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.ClientResponse;
import java.net.URLEncoder;


/**
 *
 * @author Marcel Judth
 */
public class Database {
    private static Database database;

    private static final String uri = "https://need-a-ticket-api.herokuapp.com/graphql/?query=" + URLEncoder.encode("{users{_id}}");
    private static Gson gson = null;

    
    public Database() {
        gson = new Gson();
    }
    
    
    public static void getUsers() throws Exception{
        Client client = Client.create();
        
        ClientResponse response = client.resource(uri).accept("application/json").header("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjVjODQ0ZjA0MDQ5MTZjNDBmMDBlMDg0NCIsImVtYWlsIjoianVsaWFuYmxhc2Noa2VAaWNsb3VkLmNvbSIsImlhdCI6MTU1MjgxNjcwNywiZXhwIjoxNTg0Mzc0MzA3fQ.RSepP7c49N0vnL3SYuk_2pCqs6xcYbcAC_tJSsij6P4").get(ClientResponse.class);

        if (response.getStatus() != 200) {
            throw new Exception("Failed to load teachers!");
        }

        String roomsAsString = response.getEntity(String.class); //server sends gson.toJson which is a string and we receive it here
        System.out.println(roomsAsString);
        //new TypeToken is if you have a collection
    }
    
}
