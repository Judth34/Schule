/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgServices;

import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.PathParam;
import javax.ws.rs.core.MediaType;
import pkgData.Database;
import pkgData.Producer;

/**
 * REST Web Service
 *
 * @author org
 */
@Path("ProducerDetail")
public class ProducerDetail {

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of Producer
     */
    public ProducerDetail() {
    }

    /**
     * Retrieves representation of an instance of pkgServices.Producer
     * http://localhost:8080/WebServerProducts/webresources/ProducerDetail/22
     * @param id
     * @return an instance of java.lang.String
     */
    @GET
    @Produces({MediaType.APPLICATION_JSON, MediaType.APPLICATION_XML})
    @Path("{producerid}")
    public Producer getProducer(@PathParam("producerid") String id) {
        Producer retProducer;
        try {
            Database db = Database.newInstance();
            retProducer = db.getProducer(Integer.parseInt(id));
        } catch (Exception e) {
            retProducer = new Producer(e.getMessage());
        }
        return retProducer;
    }

    /**
     * PUT method for updating or creating an instance of Producer
     *
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_XML)
    public void putXml(String content) {
    }
}
