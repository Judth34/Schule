/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgService;

import javax.jws.WebMethod;
import javax.jws.WebService;

/**
 *
 * @author Marcel Judth
 */

@WebService
public class HelloWorldTestService {

    private final String message = "Hello World";
    
    @WebMethod
    public String sayHello(){
        return this.message;
    }
}
