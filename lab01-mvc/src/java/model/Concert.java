/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package model;

import javax.annotation.ManagedBean;

/**
 *
 * @author Ah Lun Tang
 */
@ManagedBean
//TODO scope
public class Concert {
    private String titel;
    private double prijsNormaal, prijsReductie;
    
    public Concert(){}
    
    public Concert(String titel, double prijsNormaal, double prijsReductie){
        this.titel = titel;
        this.prijsNormaal = prijsNormaal;
        this.prijsReductie = prijsReductie;
    }

    /**
     * @return the titel
     */
    public String getTitel() {
        return titel;
    }

    /**
     * @param titel the titel to set
     */
    public void setTitel(String titel) {
        this.titel = titel;
    }

    /**
     * @return the prijsNormaal
     */
    public double getPrijsNormaal() {
        return prijsNormaal;
    }

    /**
     * @param prijsNormaal the prijsNormaal to set
     */
    public void setPrijsNormaal(double prijsNormaal) {
        this.prijsNormaal = prijsNormaal;
    }

    /**
     * @return the prijsReductie
     */
    public double getPrijsReductie() {
        return prijsReductie;
    }

    /**
     * @param prijsReductie the prijsReductie to set
     */
    public void setPrijsReductie(double prijsReductie) {
        this.prijsReductie = prijsReductie;
    }
    
}
