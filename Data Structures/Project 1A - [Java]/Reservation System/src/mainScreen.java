package dataProjectPart_II;

import java.util.ArrayList;

import org.eclipse.swt.widgets.Display;
import org.eclipse.swt.widgets.Shell;
import org.eclipse.swt.widgets.ProgressBar;
import org.eclipse.swt.SWT;
import org.eclipse.swt.widgets.Label;
import org.eclipse.swt.widgets.Text;
import org.eclipse.swt.widgets.Button;
import org.eclipse.swt.widgets.Combo;
import org.eclipse.swt.events.SelectionAdapter;
import org.eclipse.swt.events.SelectionEvent;
import org.eclipse.swt.events.KeyAdapter;
import org.eclipse.swt.events.KeyEvent;
import org.eclipse.wb.swt.SWTResourceManager;

public class mainScreen {

	protected static Shell shell;
	 //masada oturacaklar listesine indexlemeyle eriþebilmek icin arraylist yaratýldý
	private static ArrayList<Text> txtKisler = new ArrayList<Text>(); 
	//masalarýn doluluk yüzzdesi belirlenirken ilerleme çubuklarýna indexlemeyle eriþebilme için yaratýldý
	private static ArrayList<ProgressBar> pbarList = new ArrayList<ProgressBar>();
	//masalarýn doluluk yüzzdesi ve oturan kiþileri belirlerken indexlemeyle ulaþabilmek için yaratýldý
	private static ArrayList<Label> lblList = new ArrayList<Label>();

	/**
	 * Launch the application.
	 * @param args
	 * @throws InterruptedException 
	 */
	public static void main(String[] args) throws InterruptedException {
		try {
			mainScreen window = new mainScreen();
			window.open();
			
		} catch (Exception e) {
			e.printStackTrace();
		}
}
	
	public void open() {
		Display display = Display.getDefault();
		shell = new Shell(SWT.CLOSE | SWT.MIN | SWT.TITLE);
		shell.setImage(SWTResourceManager.getImage(mainScreen.class, "/com/sun/java/swing/plaf/motif/icons/DesktopIcon.gif"));
		shell.setTouchEnabled(true);
		shell.setSize(999, 718);
		shell.setText("Rezervasyon Sistemi");
		createContents();
		shell.open();
		shell.layout();
		
	    while (!shell.isDisposed()) {
	      if (!display.readAndDispatch())
	        display.sleep();
	      }
	    display.dispose();
	}

	private static void createContents() {
		
		ProgressBar barMasa1 = new ProgressBar(shell, SWT.NONE);
		barMasa1.setBounds(173, 27, 801, 17);

		ProgressBar barMasa2 = new ProgressBar(shell, SWT.NONE);
		barMasa2.setBounds(173, 89, 801, 17);
		
		ProgressBar barMasa4 = new ProgressBar(shell, SWT.NONE);
		barMasa4.setBounds(173, 215, 801, 17);
		
		ProgressBar barMasa5 = new ProgressBar(shell, SWT.NONE);
		barMasa5.setBounds(173, 279, 801, 17);
		
		ProgressBar barMasa3 = new ProgressBar(shell, SWT.NONE);
		barMasa3.setBounds(173, 156, 801, 17);
		
		ProgressBar barMasa6 = new ProgressBar(shell, SWT.NONE);
		barMasa6.setBounds(173, 342, 801, 17);
		
		ProgressBar barMasa7 = new ProgressBar(shell, SWT.NONE);
		barMasa7.setBounds(173, 394, 801, 17);
		
		ProgressBar barMasa8 = new ProgressBar(shell, SWT.NONE);
		barMasa8.setBounds(173, 440, 801, 17);
		
		ProgressBar barMasa10 = new ProgressBar(shell, SWT.NONE);
		barMasa10.setBounds(173, 540, 801, 17);
		
		ProgressBar barMasa9 = new ProgressBar(shell, SWT.NONE);
		barMasa9.setToolTipText("");
		barMasa9.setBounds(173, 490, 801, 17);
		
		ProgressBar barRestorant = new ProgressBar(shell, SWT.NONE);
		barRestorant.setBounds(173, 590, 801, 17);
		
		pbarList.add(barMasa1);
		pbarList.add(barMasa2);
		pbarList.add(barMasa3);
		pbarList.add(barMasa4);
		pbarList.add(barMasa5);
		pbarList.add(barMasa6);
		pbarList.add(barMasa7);
		pbarList.add(barMasa8);
		pbarList.add(barMasa9);
		pbarList.add(barMasa10);
		pbarList.add(barRestorant);	
		
		Label lblNewLabel = new Label(shell, SWT.NONE);
		lblNewLabel.setBounds(10, 27, 81, 15);
		lblNewLabel.setText("1. Masa(10 ki\u015Fi)");
		
		Label lblMasaKii = new Label(shell, SWT.NONE);
		lblMasaKii.setText("2. Masa(10 ki\u015Fi)");
		lblMasaKii.setBounds(10, 89, 81, 15);
		
		Label lblMasaKii_1 = new Label(shell, SWT.NONE);
		lblMasaKii_1.setText("3. Masa(8 ki\u015Fi)");
		lblMasaKii_1.setBounds(10, 156, 81, 15);
		
		Label lblMasa = new Label(shell, SWT.NONE);
		lblMasa.setText("4. Masa(8 ki\u015Fi)");
		lblMasa.setBounds(10, 215, 81, 15);
		
		Label lblMasaKii_2 = new Label(shell, SWT.NONE);
		lblMasaKii_2.setText("5. Masa(8 ki\u015Fi)");
		lblMasaKii_2.setBounds(10, 279, 81, 15);
		
		Label lblMasaKii_3 = new Label(shell, SWT.NONE);
		lblMasaKii_3.setText("6. Masa(4 Ki\u015Fi)");
		lblMasaKii_3.setBounds(10, 342, 81, 15);
		
		Label lblMasaKii_4 = new Label(shell, SWT.NONE);
		lblMasaKii_4.setText("7. Masa(4 Ki\u015Fi)");
		lblMasaKii_4.setBounds(10, 394, 75, 15);
		
		Label lblMasaKii_5 = new Label(shell, SWT.NONE);
		lblMasaKii_5.setText("8. Masa(4 Ki\u015Fi)");
		lblMasaKii_5.setBounds(10, 442, 75, 15);
		
		Label lblMasaKii_6 = new Label(shell, SWT.NONE);
		lblMasaKii_6.setText("9. Masa(4 Ki\u015Fi)");
		lblMasaKii_6.setBounds(10, 492, 81, 15);
		
		Label lblRestorantGeneli = new Label(shell, SWT.NONE);
		lblRestorantGeneli.setFont(SWTResourceManager.getFont("Segoe UI", 10, SWT.BOLD));
		lblRestorantGeneli.setText("      Restorant \n        Geneli");
		lblRestorantGeneli.setBounds(0, 590, 91, 45);
		
		Label lblMasaKii_7 = new Label(shell, SWT.NONE);
		lblMasaKii_7.setText("10. Masa(4 Ki\u015Fi)");
		lblMasaKii_7.setBounds(10, 542, 81, 15);
		
		Text txt1 = new Text(shell, SWT.BORDER);
		txt1.setEditable(false);
		txt1.setBounds(10, 48, 964, 35);
		
		Text txt2 = new Text(shell, SWT.BORDER);
		txt2.setEditable(false);
		txt2.setBounds(10, 112, 964, 35);
		
		Text txt3 = new Text(shell, SWT.BORDER);
		txt3.setEditable(false);
		txt3.setBounds(10, 179, 964, 35);
		
		Text txt10 = new Text(shell, SWT.BORDER);
		txt10.setEditable(false);
		txt10.setBounds(10, 563, 964, 21);
		
		Text txt9 = new Text(shell, SWT.BORDER);
		txt9.setEditable(false);
		txt9.setBounds(10, 513, 964, 21);
		
		Text txt8 = new Text(shell, SWT.BORDER);
		txt8.setEditable(false);
		txt8.setBounds(10, 463, 964, 21);
		
		Text txt7 = new Text(shell, SWT.BORDER);
		txt7.setEditable(false);
		txt7.setBounds(10, 415, 964, 21);
		
		Text txt6 = new Text(shell, SWT.BORDER);
		txt6.setEditable(false);
		txt6.setBounds(10, 365, 964, 21);
		
		Text txt4 = new Text(shell, SWT.BORDER);
		txt4.setEditable(false);
		txt4.setBounds(10, 238, 964, 35);
		
		Text txt5 = new Text(shell, SWT.BORDER);
		txt5.setEditable(false);
		txt5.setBounds(10, 302, 964, 35);
		txtKisler.add(txt1);
		txtKisler.add(txt2);
		txtKisler.add(txt3);
		txtKisler.add(txt4);
		txtKisler.add(txt5);
		txtKisler.add(txt6);
		txtKisler.add(txt7);
		txtKisler.add(txt8);
		txtKisler.add(txt9);
		txtKisler.add(txt10);
		
		
		final Combo combo = new Combo(shell, SWT.NONE);
		combo.addKeyListener(new KeyAdapter() {
			@Override
			public void keyPressed(KeyEvent e) {
				combo.setText("");
				java.awt.Toolkit.getDefaultToolkit().beep();
			}
			@Override
			public void keyReleased(KeyEvent e) {
				combo.setText("");
			}
		});

		combo.setTouchEnabled(true);
		combo.setItems(new String[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"});
		combo.setBounds(552, 631, 63, 23);

		
		Button btnNewButton = new Button(shell, SWT.NONE);
		btnNewButton.addSelectionListener(new SelectionAdapter() {
			@Override
			public void widgetSelected(SelectionEvent e) {
				if(combo.getSelectionIndex()!=-1){
				for (ProgressBar pBar:pbarList) {
					pBar.setSelection(0);
				}
					masa masa = new masa();
					masa.masalariYazdir(pbarList, lblList, txtKisler, combo.getSelectionIndex()+1);
				}
			}
		});
		btnNewButton.setBounds(674, 614, 210, 55);
		btnNewButton.setText("DA\u011EIT");
		
		Label lblMasa1 = new Label(shell, SWT.RIGHT);
		lblMasa1.setBounds(85, 27, 82, 15);
		lblMasa1.setText("0");
		
		Label lblMasa2 = new Label(shell, SWT.NONE);
		lblMasa2.setAlignment(SWT.RIGHT);
		lblMasa2.setBounds(94, 91, 73, 15);
		lblMasa2.setText("0");
		
		Label lblMasa3 = new Label(shell, SWT.NONE);
		lblMasa3.setText("0");
		lblMasa3.setAlignment(SWT.RIGHT);
		lblMasa3.setBounds(97, 158, 70, 15);
		
		Label lblMasa4 = new Label(shell, SWT.NONE);
		lblMasa4.setText("0");
		lblMasa4.setAlignment(SWT.RIGHT);
		lblMasa4.setBounds(96, 217, 71, 15);
		
		Label lblMasa5 = new Label(shell, SWT.NONE);
		lblMasa5.setText("0");
		lblMasa5.setAlignment(SWT.RIGHT);
		lblMasa5.setBounds(97, 281, 70, 15);
		
		Label lblMasa6 = new Label(shell, SWT.NONE);
		lblMasa6.setText("0");
		lblMasa6.setAlignment(SWT.RIGHT);
		lblMasa6.setBounds(97, 342, 70, 15);
		
		Label lblMasa7 = new Label(shell, SWT.NONE);
		lblMasa7.setText("0");
		lblMasa7.setAlignment(SWT.RIGHT);
		lblMasa7.setBounds(97, 394, 70, 15);
		
		Label lblMasa8 = new Label(shell, SWT.NONE);
		lblMasa8.setText("0");
		lblMasa8.setAlignment(SWT.RIGHT);
		lblMasa8.setBounds(97, 440, 70, 15);
		
		Label lblMasa9 = new Label(shell, SWT.NONE);
		lblMasa9.setText("0");
		lblMasa9.setAlignment(SWT.RIGHT);
		lblMasa9.setBounds(97, 490, 70, 15);
		
		Label lblMasa10 = new Label(shell, SWT.NONE);
		lblMasa10.setText("0");
		lblMasa10.setAlignment(SWT.RIGHT);
		lblMasa10.setBounds(97, 540, 70, 15);
		
		Label lblRestorant = new Label(shell, SWT.NONE);
		lblRestorant.setText("0");
		lblRestorant.setAlignment(SWT.RIGHT);
		lblRestorant.setBounds(85, 592, 82, 15);
		
		Label lblArtanlar = new Label(shell, SWT.NONE);
		lblArtanlar.setForeground(SWTResourceManager.getColor(SWT.COLOR_RED));
		lblArtanlar.setFont(SWTResourceManager.getFont("Segoe UI", 12, SWT.BOLD));
		lblArtanlar.setBounds(97, 618, 314, 56);
		lblArtanlar.setText("");
		
		lblList.add(lblMasa1);
		lblList.add(lblMasa2);
		lblList.add(lblMasa3);
		lblList.add(lblMasa4);
		lblList.add(lblMasa5);
		lblList.add(lblMasa6);
		lblList.add(lblMasa7);
		lblList.add(lblMasa8);
		lblList.add(lblMasa9);
		lblList.add(lblMasa10);
		lblList.add(lblRestorant);
		lblList.add(lblArtanlar);
		
		Label lblKiiSays = new Label(shell, SWT.NONE);
		lblKiiSays.setBounds(491, 634, 55, 15);
		lblKiiSays.setText("Ki\u015Fi Say\u0131s\u0131");

	}
}
