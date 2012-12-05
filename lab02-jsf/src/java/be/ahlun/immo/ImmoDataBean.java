/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package be.ahlun.immo;

import be.hogent.iii.immo.interfaces.IImmoKantoor;
import be.hogent.iii.immo.interfaces.IType;
import be.hogent.iii.immo.interfaces.ImmoException;
import java.util.ArrayList;
import java.util.List;
import javax.faces.model.SelectItem;

/**
 *
 * @author ahluntang
 */
public class ImmoDataBean {
    private IImmoKantoor immoData;

    public ImmoDataBean() {
    }

    public void setImmoData(IImmoKantoor immoData) {
        this.immoData = immoData;
    }

    public List<SelectItem> getGebouwTypes() {
        List<SelectItem> gebouwTypes = new ArrayList<SelectItem>();
        try {
            List<IType> types = immoData.getGebouwTypes();
            for (IType type : types) {
                gebouwTypes.add(new SelectItem(type.getId(), type.getNaam()));
            }
        } catch (ImmoException e) {
        }
        return gebouwTypes;
    }
}
