package be.ahlun.immo;

import be.hogent.iii.immo.interfaces.IImmoKantoor;
import be.hogent.iii.immo.interfaces.IPand;
import be.hogent.iii.immo.interfaces.IType;
import be.hogent.iii.immo.interfaces.ImmoException;
import java.util.List;

/**
 *
 * @author ahluntang
 */
public class ImmoSearch {

    private int immotype;
    private double min, max;
    private List<IPand> immotypes;
    private IImmoKantoor immoData;

    public ImmoSearch() {
    }

    /**
     * @return the immotype
     */
    public int getImmotype() {
        return immotype;
    }

    /**
     * @param immotype the immotype to set
     */
    public void setImmotype(int immotype) {
        this.immotype = immotype;
    }

    /**
     * @return the min
     */
    public double getMin() {
        return min;
    }

    /**
     * @param min the min to set
     */
    public void setMin(double min) {
        this.min = min;
    }

    /**
     * @return the max
     */
    public double getMax() {
        return max;
    }

    /**
     * @param max the max to set
     */
    public void setMax(double max) {
        this.max = max;
    }

    /**
     * @return the immotypes
     */
    public List<IPand> getImmotypes() {
        return immotypes;
    }

    /**
     * @param immotypes the immotypes to set
     */
    public void setImmotypes(List<IPand> immotypes) {
        this.immotypes = immotypes;
    }

    /**
     * @return the immoData
     */
    public IImmoKantoor getImmoData() {
        return immoData;
    }

    /**
     * @param immoData the immoData to set
     */
    public void setImmoData(IImmoKantoor immoData) {
        this.immoData = immoData;
    }

    public String searchImmo() {
        boolean found = false;
        String result = "notfound";
        found = true;
        try {
            immotypes = immoData.getPanden(getImmotype(), getMin(), getMax());
            if (!immotypes.isEmpty()) {
                result = "found";
                found = false;
            }
        } catch (ImmoException e) {
        }
        return result;
    }
}
