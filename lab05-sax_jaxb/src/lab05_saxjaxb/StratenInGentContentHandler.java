package lab05_saxjaxb;

import generated.Nummers;
import generated.ObjectFactory;
import generated.Stadsdeel;
import generated.Stadsdelen;
import generated.Straat;
import generated.Wijk;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.math.BigInteger;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import org.xml.sax.Attributes;
import org.xml.sax.Locator;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

public class StratenInGentContentHandler extends DefaultHandler {

    /*
     * naam van het laatste element waarvoor de parser een event opriep
     */
    private String naamLaatsteElement;
    private HashMap<String, Stadsdeel> stadsdelen = new HashMap<String, Stadsdeel>();
    private HashMap<String, Wijk> wijken = new HashMap<String, Wijk>();
    private Stadsdelen xml;

    public StratenInGentContentHandler() {
        ObjectFactory factory = new ObjectFactory();
        xml = factory.createStadsdelen();
        naamLaatsteElement = null;
    }

    @Override
    public void endDocument() throws SAXException {
        try {
            JAXBContext jctx = JAXBContext.newInstance("generated");
            Marshaller m = jctx.createMarshaller();
            m.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, Boolean.TRUE);
            m.marshal(xml, System.out);
            m.marshal(xml, new FileOutputStream("output.xml"));
        } catch (JAXBException ex) {
            Logger.getLogger(StratenInGentContentHandler.class.getName()).log(Level.SEVERE, null, ex);
        } catch (FileNotFoundException ex) {
            Logger.getLogger(StratenInGentContentHandler.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public void startElement(String namespaceURI, String localName,
            String qualifiedName, Attributes atts) throws SAXException {

        if (qualifiedName.equalsIgnoreCase("StratenInGent") && atts.getQName(0).equalsIgnoreCase("postcode")) {

            OudeStraat oudestraat = new OudeStraat();
            oudestraat.setPostcode(atts.getValue("postcode"));
            oudestraat.setStraatcode(atts.getValue("straatcode"));
            oudestraat.setStraatnaam(atts.getValue("straatnaam"));
            oudestraat.setOnpaar_van(atts.getValue("onpaar_van"));
            oudestraat.setOnpaar_tot(atts.getValue("onpaar_tot"));
            oudestraat.setPaar_van(atts.getValue("paar_van"));
            oudestraat.setPaar_tot(atts.getValue("paar_tot"));
            oudestraat.setSector(atts.getValue("sector"));
            oudestraat.setStadsdeel(atts.getValue("stadsdeel"));
            oudestraat.setWijkNr(atts.getValue("wijkNr"));
            //outputXML.voegStadsdeelToe(oudestraat);


            ObjectFactory factory = new ObjectFactory();
            Straat straat = factory.createStraat();
            BigInteger code = BigInteger.valueOf(Long.parseLong(oudestraat.getStraatcode()));
            straat.setCode(code);
            straat.setNaam(oudestraat.getStraatnaam());

            Nummers onpaar = factory.createNummers();
            onpaar.setVan(oudestraat.getOnpaar_van());
            onpaar.setTot(oudestraat.getOnpaar_tot());
            Nummers paar = factory.createNummers();
            paar.setVan(oudestraat.getPaar_van());
            paar.setTot(oudestraat.getPaar_tot());
            straat.setOnpaar(onpaar);
            straat.setPaar(paar);

            BigInteger postcode = BigInteger.valueOf(Long.parseLong(oudestraat.getPostcode()));
            straat.setPostcode(postcode);

            straat.setSector(oudestraat.getSector());

            //stadsdeel
            Stadsdeel stadsdeel;
            if (stadsdelen.containsKey(oudestraat.getStadsdeel())) {
                stadsdeel = stadsdelen.get(oudestraat.getStadsdeel());
            } else {
                stadsdeel = factory.createStadsdeel();
                stadsdeel.setNaam(oudestraat.getStadsdeel());
                xml.getStadsdeel().add(stadsdeel);
                stadsdelen.put(oudestraat.getStadsdeel(), stadsdeel);
            }

            // wijk
            Wijk wijk;
            if (wijken.containsKey(oudestraat.getWijkNr())) {
                wijk = wijken.get(oudestraat.getWijkNr());

            } else {
                wijk = factory.createWijk();
                wijk.setNaam(oudestraat.getWijknaam());
                BigInteger wijknr = BigInteger.valueOf(Long.parseLong(oudestraat.getWijkNr()));
                wijk.setNr(wijknr);
                stadsdeel.getWijk().add(wijk);
                wijken.put(oudestraat.getWijkNr(), wijk);
            }
            wijk.getStraat().add(straat);
        } else {
            //this is not a correct node
            //possibly the root node
        }


    }
}