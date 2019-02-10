/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgServices;

import java.util.Collection;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;
import javax.ws.rs.Produces;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.core.MediaType;
import pkgData.Database;
import pkgData.Producer;

/**
 * REST Web Service
 *
 * @author org
 */
@Path("ProducerList")
public class ProducerList {

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of ProducerList
     */
    public ProducerList() {
    }

    /**
     * Retrieves representation of an instance of pkgServices.ProducerList
     * @return an instance of Collection<Producer>
     */
 	@GET
	@Produces({MediaType.APPLICATION_JSON, MediaType.APPLICATION_XML})
	public Collection<Producer> getProducers() throws Exception {
		Database db = Database.newInstance();
		return db.getAllProducers();
	}
}
