/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package ws;

import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import java.lang.Math;

/**
 *
 * @author Ah Lun Tang
 */
@WebService(serviceName = "EquationService")
public class EquationService {

    /**
     * This is a sample web service operation
     */
    @WebMethod(operationName = "hello")
    public String hello(@WebParam(name = "name") String txt) {
        return "Hello " + txt + " !";
    }
    
    @WebMethod(operationName = "solveQuadratic")
    public double[] solveQuadratic(double a, double b, double c) {
        double[] result = new double[3];
        //ax^2+bx+c
        double discriminant = b*b-4*a*c;
        if(discriminant >= 0){
            double x1,x2;
            x1 = (-b+Math.sqrt(discriminant))/(2*a);
            x2 = (-b-Math.sqrt(discriminant))/(2*a);
            result[0] = x1;
            result[1]= x2;
        }
        return result;
    }
}
