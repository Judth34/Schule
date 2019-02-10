/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package org.prod.data;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import java.lang.reflect.Type;
import java.util.ArrayList;
import org.prod.misc.ControllerSync;

/**
 *
 * @author org
 */
public class Database {

    private static Database db = null;
    private static ControllerSync controller = null;
    private static String url = null;
    /**
     * Singleton
     */
    private Database() {
    }

    public static Database newInstance() {
        if (db == null) {
            db = new Database();
        }
        return db;
    }
    public static void setURL(String _url) {
        url = _url;
    }

    public ArrayList<Producer> getProducers() throws Exception {
        Gson gson = new Gson();

        //String strFromWebService = "[{\"id\":22,\"name\":\"Scheiben AG\"},{\"id\":33,\"name\":\"CeDe AG\",\"sales\":10000.11},{\"id\":44,\"name\":\"ÖFBB\",\"sales\":5000.55},{\"id\":55,\"name\":\"DFBB\",\"sales\":1000.1},{\"id\":66,\"name\":\"Haitek\",\"sales\":909.9},{\"id\":77,\"name\":\"Kornblum\"}]";

        //each call needs an new instance of async !!
	controller = new ControllerSync(url);

	controller.execute("PRODUCERLIST");
	String strFromWebService = controller.get();
        System.out.println("=========" + strFromWebService);
        Type collectionType = new TypeToken<ArrayList<Producer>>() {}.getType();
        ArrayList<Producer> vec = gson.fromJson(strFromWebService, collectionType);

        return vec;
    }
    public ArrayList<Product> getProducts() throws Exception {
        Gson gson = new Gson();

        //String strFromWebService = "[{"id":110,"name":"Frisby","onMarket":"2002-04-11","onStock":200},{"id":120,"name":"Frisby","onMarket":"2012-11-08","onStock":200},{"id":130,"name":"Ball","onMarket":"2009-02-15","onStock":190},{"id":140,"name":"Ball","onMarket":"1992-01-11","onStock":2},{"id":150,"name":"Fidschi Gogerl","onMarket":"2013-07-01","onStock":1000},{"id":160,"name":"Fidschi Gogerl","onMarket":"2013-08-11","onStock":10},{"id":170,"name":"Fidschi Gogerl","onMarket":"2002-04-05","onStock":22},{"id":180,"name":"Murmel","onMarket":"2010-11-13","onStock":802},{"id":190,"name":"Waveboard","onMarket":"2011-11-13","onStock":402}]";

        //each call needs an new instance of async !!
	controller = new ControllerSync(url);

	controller.execute("PRODUCTLIST");
	String strFromWebService = controller.get();
        System.out.println("=========" + strFromWebService);
        Type collectionType = new TypeToken<ArrayList<Product>>() {}.getType();
        ArrayList<Product> vec = gson.fromJson(strFromWebService, collectionType);

        return vec;
    }
    
    public Product getProduct(int id) throws Exception {
        Gson gson = new Gson();
        Product retProduct;

        //String strFromWebService = "[{"id":110,"name":"Frisby","onMarket":"2002-04-11","onStock":200},{"id":120,"name":"Frisby","onMarket":"2012-11-08","onStock":200},{"id":130,"name":"Ball","onMarket":"2009-02-15","onStock":190},{"id":140,"name":"Ball","onMarket":"1992-01-11","onStock":2},{"id":150,"name":"Fidschi Gogerl","onMarket":"2013-07-01","onStock":1000},{"id":160,"name":"Fidschi Gogerl","onMarket":"2013-08-11","onStock":10},{"id":170,"name":"Fidschi Gogerl","onMarket":"2002-04-05","onStock":22},{"id":180,"name":"Murmel","onMarket":"2010-11-13","onStock":802},{"id":190,"name":"Waveboard","onMarket":"2011-11-13","onStock":402}]";

        //each call needs an new instance of async !!
	controller = new ControllerSync(url);

        String paras[] = new String[2];
        paras[0] = "PRODUCTDETAIL";
        paras[1] = Integer.toString(id);
	controller.execute(paras);
	String strFromWebService = controller.get();
        System.out.println("=========" + strFromWebService);
        retProduct = gson.fromJson(strFromWebService, Product.class);

        return retProduct;
    }
    
    public String updateProduct(Product product) throws Exception {
        Gson gson = new Gson();
        //each call needs an new instance of async !!
	controller = new ControllerSync(url);
        
        String strProduct = gson.toJson(product,Product.class);
        System.out.println("===========" + product);
        System.out.println("=========2==" + strProduct);
        String paras[] = new String[2];
        paras[0] = "PRODUCTUPDATE";
        paras[1] = strProduct;
	controller.execute(paras);
        return controller.get();
    }
}
