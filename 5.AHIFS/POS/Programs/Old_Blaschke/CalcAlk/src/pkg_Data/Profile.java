/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_Data;

import java.io.Serializable;

/**
 *
 * @author schueler
 */
public class Profile implements Comparable<Profile>,Serializable{
    
    private static final long serialVersionUID = 2L;
    String name;
    ProfileType type;
    int weight;

    public Profile(String name, ProfileType type, int weight) {
        this.name = name;
        this.type = type;
        this.weight = weight;
    }

    public Profile() {
    }

    
    public String getName() {
        return name;
    }

    public ProfileType getType() {
        return type;
    }

    public int getWeight() {
        return weight;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setType(ProfileType type) {
        this.type = type;
    }

    public void setWeight(int weight) {
        this.weight = weight;
    }

    @Override
    public int compareTo(Profile profile) {
        if(this.name.compareToIgnoreCase(profile.getName()) == 0)
            return this.weight - profile.getWeight();
        return this.name.compareToIgnoreCase(profile.getName());
    }

    @Override
    public String toString() {
        return name + " , "+ weight + "kg, " + type.toString().toLowerCase();
    }
    
    
    
    
    
}
