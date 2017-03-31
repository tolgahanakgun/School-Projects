package dataProjectPart_II;

import org.eclipse.swt.widgets.Display;
import org.eclipse.swt.widgets.Shell;
import org.eclipse.swt.widgets.TableItem;
import org.eclipse.swt.SWT;
import org.eclipse.swt.widgets.Table;
import org.eclipse.wb.swt.SWTResourceManager;

public class ayaktaKalanlarForm {

	protected Shell shell;
	private Table table;
	String[] ayaktaKalanlarStrings;

	/**
	 * Launch the application.
	 * @param args
	 */
	public ayaktaKalanlarForm(String[] ayaktaKalanlar) {
		this.ayaktaKalanlarStrings = ayaktaKalanlar;
	}
	public ayaktaKalanlarForm() {}
	public static void main(String[] args) {
		try {
			ayaktaKalanlarForm window = new ayaktaKalanlarForm();
			window.open();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	/**
	 * Open the window.
	 */
	public void open() {
		Display display = Display.getDefault();
		createContents();
		shell.open();
		shell.layout();
		while (!shell.isDisposed()) {
			if (!display.readAndDispatch()) {
				display.sleep();
			}
		}
	}

	/**
	 * Create contents of the window.
	 */
	protected void createContents() {
		shell = new Shell(SWT.CLOSE | SWT.MIN | SWT.TITLE);
		shell.setFullScreen(true);
		shell.setSize(259, 300);
		shell.setImage(SWTResourceManager.getImage(mainScreen.class, "/com/sun/java/swing/plaf/motif/icons/DesktopIcon.gif"));
		shell.setText("Ayakta Kalanlar");
		shell.setLocation(mainScreen.shell.getLocation().x+mainScreen.shell.getSize().x/2-shell.getSize().x/2,
				mainScreen.shell.getLocation().y+mainScreen.shell.getSize().y/2-shell.getSize().y/2);
		
		table = new Table(shell, SWT.BORDER | SWT.FULL_SELECTION);
		table.setBounds(10, 10, 234, 241);
		table.setHeaderVisible(true);
		table.setLinesVisible(true);
		org.eclipse.swt.widgets.TableColumn tc1 = new org.eclipse.swt.widgets.TableColumn(table, SWT.NONE);
		tc1.setText("                        Adý-Soyadý");
		tc1.setWidth(table.getSize().x-5);
		int j=1;
		for(int i=64;i<ayaktaKalanlarStrings.length;i++){
			TableItem tableItem = new TableItem(table, 0);
			tableItem.setText(String.valueOf(j)+". "+ayaktaKalanlarStrings[i]);
			j++;
		}
	}
}
