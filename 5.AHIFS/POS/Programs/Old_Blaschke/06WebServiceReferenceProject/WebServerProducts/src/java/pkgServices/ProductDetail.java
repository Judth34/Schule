/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgServices;

import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;
import javax.ws.rs.Consumes;
import javax.ws.rs.Produces;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.PathParam;
import javax.ws.rs.core.MediaType;
import pkgData.Database;
import pkgData.Product;

/**
 * REST Web Service
 *
 * @author Gerald
 */
@Path("ProductDetail")
public class ProductDetail {

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of ProductDetail
     */
    public ProductDetail() {
    }

    /**
     * Retrieves representation of an instance of pkgServices.Producer
     * http://localhost:8080/WebServerProducts/webresources/ProducerDetail/22
     * @param id
     * @return an instance of java.lang.String
     */
    @GET
    @Produces({MediaType.APPLICATION_JSON, MediaType.APPLICATION_XML})
    @Path("{productid}")
    public Product getProduct(@PathParam("productid") String id) {
        Product retProduct;
        try {
            System.out.println("*******get product id:*******" + id);
            Database db = Database.newInstance();
            retProduct = db.getProduct(Integer.parseInt(id));
        } catch (Exception e) {
            retProduct = new Product(e.getMessage());
        }
        return retProduct;
    }

	@POST
	@Consumes({MediaType.APPLICATION_JSON, MediaType.APPLICATION_XML})
	public String newProduct(Product product) throws Exception {
		String retValue = "ok";
		Database db = Database.newInstance();
                System.out.println("*******new product*******");
		try {
			db.addProduct(product);
		} catch (Exception e) {
			retValue = e.getMessage();
		}

		return retValue;
	}
	@PUT
	@Consumes({MediaType.APPLICATION_JSON, MediaType.APPLICATION_XML})
	public String updateProduct(Product product) throws Exception {
		String retValue = "update ok";
		Database db = Database.newInstance();
                System.out.println("*******update product*******" + product);
                System.out.println("******* with producer*******" + product.getProducer());
		try {
                    db.updateProduct(product);
		}
		  catch (Exception e) {
			retValue = "error: " + e.getMessage();
                        System.out.println("error update product*******" + e.getMessage());
		}

		return retValue;
	}


}
