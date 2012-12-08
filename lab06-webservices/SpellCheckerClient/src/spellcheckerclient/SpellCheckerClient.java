/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package spellcheckerclient;

import java.util.Iterator;
import java.util.Scanner;

/**
 *
 * @author Ah Lun Tang
 */
public class SpellCheckerClient {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Check check = new Check();
        CheckSoap cs = check.getCheckSoap();
        DocumentSummary doc = cs.checkTextBodyV2("This is Kool");
        checkResult(doc);
        String s;
        s = sc.nextLine();
        while(!s.equalsIgnoreCase("STOP")){
            doc = cs.checkTextBodyV2(s);
            checkResult(doc);
            s = sc.nextLine();
        
        }
    }
    
    public static void checkResult(DocumentSummary doc) {
        Iterator it = doc.misspelledWord.iterator();
        while(it.hasNext()){
          Words words = (Words) it.next();
          System.out.println(words.word);
        }
    }
}
