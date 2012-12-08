package lab05_saxjaxb;

import java.io.IOException;
import java.net.URL;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.xml.sax.InputSource;
import org.xml.sax.SAXException;
import org.xml.sax.XMLReader;
import org.xml.sax.helpers.XMLReaderFactory;

/**
 *
 * @author ahluntang
 */
public class Lab05_saxjaxb {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        String url = "http://datatank.gent.be/Grondgebied/StratenInGent.xml";
        try {
            // the SAX way:
            XMLReader myReader = XMLReaderFactory.createXMLReader();
            StratenInGentContentHandler handler = new StratenInGentContentHandler();
            myReader.setContentHandler(handler);
            myReader.parse(new InputSource(new URL(url).openStream()));
        } catch (SAXException ex) {
            Logger.getLogger(Lab05_saxjaxb.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ex) {
            Logger.getLogger(Lab05_saxjaxb.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
