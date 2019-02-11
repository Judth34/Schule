/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package org.prod;

import android.app.Activity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;
import java.text.SimpleDateFormat;
import org.prod.data.Database;
import org.prod.data.Producer;
import org.prod.data.Product;

/**
 *
 * @author schueler
 */
public class ProductActivity extends Activity {
    private TextView txtMessage = null,
                     txtProduct = null;
    private EditText txtName = null,
                     txtOnStock = null,
                     txtOnMarket = null;
    private Spinner  spProducer = null;

    /**
     * non GUI components
     */
    private Database db = null;
    private Product product = null;
    /**
     * Called when the activity is first created.
     */
    @Override
    public void onCreate(Bundle icicle) {
        super.onCreate(icicle);
               setContentView(R.layout.product);

        try {
            getAllViews();
        } catch (Exception e) {
            Toast.makeText(this, "exception: " + e.getMessage(), Toast.LENGTH_LONG).show();
        }

        try {
            db = Database.newInstance();
            fillViews();
        } catch (Exception e) {
            txtMessage.setText("exception: " + e.getMessage());
        }
     
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.product_menu, menu);
        return true;
    }
    
        @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        try {
            switch (item.getItemId()) {
                case R.id.mitemSave: {
                    product.setName(txtName.getText().toString());
                    product.setOnStock(Integer.parseInt(txtOnStock.getText().toString()));
                    //product.setOnMarket(new SimpleDateFormat("dd.MMM.yyyy").parse(txtOnMarket.getText().toString()));
                    product.setProducer((Producer) spProducer.getSelectedItem());
                    String result = db.updateProduct(product);
                    txtMessage.setText(result);
                    break;
                }
            }
        } catch (Exception e) {
            txtMessage.setText("error: " + e.getMessage());
            e.printStackTrace();
        }
        return true;
    }

    private void getAllViews() {
        txtMessage = (TextView) this.findViewById(R.id.txtMessage);
        txtMessage.setEnabled(false);
        txtProduct = (TextView) this.findViewById(R.id.txtProduct);
        txtProduct.setEnabled(false);
        txtOnStock = (EditText) this.findViewById(R.id.txtOnStock);
        txtOnMarket = (EditText) this.findViewById(R.id.txtOnMarket);
        txtOnMarket.setEnabled(false);
        txtName = (EditText) this.findViewById(R.id.txtName);
        spProducer = (Spinner)this.findViewById(R.id.spProducer);
    }

    private void fillViews() throws Exception {
        product = (Product)(this.getIntent().getExtras().getSerializable("intentProduct"));
        txtProduct.setText(product.toLongString());
        txtName.setText(product.getName());
        txtOnStock.setText(Integer.toString(product.getOnStock()));
        String format = new SimpleDateFormat("dd.MMM.yyyy").format(product.getOnMarket());
        txtOnMarket.setText(format);
        txtMessage.setText("update information and press SAVE");
        fillProducers();
    }
    
    private void fillProducers() throws Exception {
        ArrayAdapter<Producer> adapterProducer = new ArrayAdapter<Producer>(
                this,
                android.R.layout.simple_spinner_item, db.getProducers());
        spProducer.setAdapter(adapterProducer);
        spProducer.setSelection(adapterProducer.getPosition(product.getProducer()));
    }

}
