/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package testequationservice;

import java.util.List;
import java.util.Scanner;
import ws.EquationService;
import ws.EquationService_Service;

/**
 *
 * @author Ah Lun Tang
 */
public class TestEquationService {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        EquationService_Service service = new EquationService_Service();
        EquationService eqservice = service.getEquationServicePort();
        List<Double> result = null;
        result = eqservice.solveQuadratic(1, -5, 6);
        
        Scanner sc = new Scanner(System.in);
        String s;
        s = sc.nextLine();
        while(!s.equalsIgnoreCase("STOP")){
            System.out.println("Geef coefficient voor x² (a):");
            s = sc.nextLine();
            Double a = Double.parseDouble(s);
            System.out.println("Geef coefficient voor x (b):");
            s = sc.nextLine();
            Double b = Double.parseDouble(s);
            System.out.println("Geef de constante (c):");
            s = sc.nextLine();
            Double c = Double.parseDouble(s);
            result = eqservice.solveQuadratic(1, -5, 6);
            for(Double val:result){
                System.out.println(val);
            }
            
        }
    }
}
