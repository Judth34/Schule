package org.prod;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.ActionMode;
import android.view.ActionMode.Callback;
import android.view.Menu;
import android.view.MenuItem;
import android.view.MenuInflater;
import android.view.View;
import android.view.View.OnLongClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;
import org.prod.data.Database;
import org.prod.data.Producer;
import org.prod.data.Product;

public class MainActivity extends Activity implements OnItemSelectedListener,
        OnLongClickListener, Callback {

    private Spinner spinnerProducer = null,
            spinnerProduct = null;
    private TextView txtMessage = null;
    private EditText txtUrl = null;
    private ActionMode mActionMode = null;
    private View hasFocusOnLongClick = null;        //needed for displaying correct context menu
    /**
     * non GUI components
     */
    private Database db = null;

    /**
     * Called when the activity is first created.
     */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);

        try {
            getAllViews();
        } catch (Exception e) {
            Toast.makeText(this, "exception: " + e.getMessage(), Toast.LENGTH_LONG).show();
        }

        try {
            db = Database.newInstance();
        } catch (Exception e) {
            txtMessage.setText("exception: " + e.getMessage());
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.main_menu, menu);
        return true;
    }

    private void getAllViews() {
        spinnerProducer = (Spinner) this.findViewById(R.id.spProducer);
        spinnerProducer.setOnItemSelectedListener(this);
        spinnerProducer.setOnLongClickListener(this);
        spinnerProducer.setLongClickable(true);
        spinnerProduct = (Spinner) this.findViewById(R.id.spProduct);
        spinnerProduct.setOnItemSelectedListener(this);
        spinnerProduct.setOnLongClickListener(this);
        spinnerProduct.setLongClickable(true);
        txtMessage = (TextView) this.findViewById(R.id.txtMessage);
        txtMessage.setEnabled(false);
        txtUrl = (EditText) this.findViewById(R.id.txtURL);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        try {
            Database.setURL(txtUrl.getText().toString());
            switch (item.getItemId()) {
                case R.id.mitemLoad: {
                    fillProducers();
                    fillProducts();
                    txtMessage.setText("load done");
                    break;
                }
            }
        } catch (Exception e) {
            txtMessage.setText("error: " + e.getMessage());
            e.printStackTrace();
        }
        return true;
    }

    @Override
    public void onItemSelected(AdapterView<?> av, View view, int i, long l) {
    }

    @Override
    public void onNothingSelected(AdapterView<?> av) {
    }

    @Override
    public boolean onLongClick(View view) {
        boolean retValue = false;
        hasFocusOnLongClick = view;
        if (mActionMode == null) {
            // Call onCreateActionMode using the ActionMode.Callback impl. 
            mActionMode = this.startActionMode(this);
            retValue = true;
        }
        return retValue;
    }

    @Override
    public boolean onCreateActionMode(ActionMode mode, Menu menu) {
        MenuInflater inflater = mode.getMenuInflater();

        if (hasFocusOnLongClick == spinnerProduct) {
            inflater.inflate(R.menu.context_product_menu, menu);
        }
        return true;
    }

    private void fillProducers() throws Exception {
        ArrayAdapter<Producer> adapterProducer = new ArrayAdapter<Producer>(
                this,
                android.R.layout.simple_spinner_item, db.getProducers());
        spinnerProducer.setAdapter(adapterProducer);
    }

    private void fillProducts() throws Exception {
        ArrayAdapter<Product> adapterProduct = new ArrayAdapter<Product>(
                this,
                android.R.layout.simple_spinner_item, db.getProducts());
        spinnerProduct.setAdapter(adapterProduct);
    }

    /**
     * following 3 event handler needed by context menu
     *
     * @param am
     * @param menu
     * @return
     */
    public boolean onPrepareActionMode(ActionMode am, Menu menu) {
        return false;
    }

    public boolean onActionItemClicked(ActionMode am, MenuItem item) {
        try {
            switch (item.getItemId()) {
                case R.id.mitemDetail: {
                    Product p = (Product) spinnerProduct.getSelectedItem();
                    p = db.getProduct(p.getId());
                    txtMessage.setText("details: " + p.toLongString());
                    break;
                }
                case R.id.mitemUpdate: {
                    Product p = (Product) spinnerProduct.getSelectedItem();
                    p = db.getProduct(p.getId());
                    Intent intent = new Intent(this, ProductActivity.class);
                    intent.putExtra("intentProduct", (Product) p);
                    startActivity(intent);
                    txtMessage.setText("details: " + p.toLongString());
                    break;
                }

            }
        } catch (Exception e) {
            txtMessage.setText("error: " + e.getMessage());
        }
        return true;
    }

    public void onDestroyActionMode(ActionMode am) {
        mActionMode = null;
    }
}
