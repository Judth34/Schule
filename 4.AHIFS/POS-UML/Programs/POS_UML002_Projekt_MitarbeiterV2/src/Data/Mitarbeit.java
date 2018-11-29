/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Data;

/**
 *
 * @author Marcel Judth
 */
public class Mitarbeit implements Comparable<Mitarbeit>{
    private Projekt projekt;
    private Mitarbeiter mitarbeiter;
    private int stunden;

    public Mitarbeit(int Svnr, String name, int kst, String bez, int Stunden) throws Exception {
        this.stunden = Stunden;
        this.projekt = this.createProjekt(kst, bez);
        this.mitarbeiter = this.createMitarbeiter(Svnr, name);
    }
    
    private Mitarbeit.Mitarbeiter createMitarbeiter(int Svnr, String name) throws Exception{
        return new Mitarbeit.Mitarbeiter(Svnr, name);
    }
    
    private Projekt createProjekt(int kst, String bez) throws Exception{
        return new Projekt(kst, bez);
    }

    public Projekt getProjekt() {
        return projekt;
    }

    public Mitarbeiter getMitarbeiter() {
        return mitarbeiter;
    }

    public int getStunden() {
        return stunden;
    }

    public void setStunden(int stunden) {
        this.stunden = stunden;
    }

    @Override
    public int compareTo(Mitarbeit o) {
        int result = this.projekt.kst - o.projekt.getKst();
        if(result  == 0)
            result = this.stunden - o.getStunden();
        return result;
    }
    
    //innerClasses
    
    public class Mitarbeiter{
        private int SvNr;
        private String name;

        private Mitarbeiter(int SvNr, String name) {
            this.setSvNr(SvNr);
            this.setName(name);
        }

        public int getSvNr() {
            return SvNr;
        }

        public void setSvNr(int SvNr) {
            this.SvNr = SvNr;
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        @Override
        public int hashCode() {
            int hash = 7;
            hash = 19 * hash + this.SvNr;
            return hash;
        }

        @Override
        public boolean equals(Object obj) {
            if (this == obj) {
                return true;
            }
            if (obj == null) {
                return false;
            }
            if (getClass() != obj.getClass()) {
                return false;
            }
            final Mitarbeiter other = (Mitarbeiter) obj;
            if (this.SvNr != other.SvNr) {
                return false;
            }
            return true;
        }

        @Override
        public String toString() {
            return "Mitarbeiter{" + "SvNr=" + SvNr + ", name=" + name + '}';
        }
    }
    
    public class Projekt{
        private int kst;
        private String bezeichnung;

        private Projekt(int kst, String bezeichnung) {
            this.setKst(kst);
            this.setBezeichnung(bezeichnung);
        }

        public int getKst() {
            return kst;
        }

        public void setKst(int kst) {
            this.kst = kst;
        }

        public String getBezeichnung() {
            return bezeichnung;
        }

        public void setBezeichnung(String bezeichnung) {
            this.bezeichnung = bezeichnung;
        }

        @Override
        public int hashCode() {
            int hash = 3;
            hash = 79 * hash + this.kst;
            return hash;
        }

        @Override
        public boolean equals(Object obj) {
            if (this == obj) {
                return true;
            }
            if (obj == null) {
                return false;
            }
            if (getClass() != obj.getClass()) {
                return false;
            }
            final Projekt other = (Projekt) obj;
            if (this.kst != other.kst) {
                return false;
            }
            return true;
        }

        @Override
        public String toString() {
            return "Projekt{" + "kst=" + kst + ", bezeichnung=" + bezeichnung + '}';
        }
    }
}
