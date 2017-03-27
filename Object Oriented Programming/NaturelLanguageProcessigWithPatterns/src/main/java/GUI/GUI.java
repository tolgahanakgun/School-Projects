package GUI;

import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JTabbedPane;
import javax.swing.JTextField;
import javax.swing.filechooser.FileNameExtensionFilter;
import javax.swing.table.DefaultTableModel;
import javax.swing.JPanel;
import javax.swing.JFileChooser;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JButton;
import LanguageIdentifier.LanguageIdentifier;
import TextSources.MultipleTextSources;
import TextSources.TextFileReader;
import TextSources.WikipediaAdapter;
import TextSources.WikipediaConnector;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.URL;
import java.util.ArrayList;
import javax.swing.JTextArea;
import javax.swing.JScrollPane;
import javax.swing.JTable;

public class GUI {

	private JFrame frame;
	private JTextField txtWikiURL;
	private LanguageIdentifier languageIdentifier = new LanguageIdentifier();

	/**
	 * @wbp.nonvisual location=784,199
	 */
	@SuppressWarnings("serial")
	private final JFileChooser fileChooser = 
			new JFileChooser(){{setFileFilter(
					new FileNameExtensionFilter("Text File","txt"));}}; 
	private JTextField textFieldFileLocation;
	private JTable table;
	private JTextField textField;
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					GUI window = new GUI();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public GUI() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.setResizable(false);
		frame.setTitle("LANGUAGE IDENTIFIER");
		frame.setBounds(100, 100, 648, 429);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(null);

		JTabbedPane tabbedPane = new JTabbedPane(JTabbedPane.TOP);
		tabbedPane.setBounds(10, 11, 624, 381);
		frame.getContentPane().add(tabbedPane);

		JPanel pnlSingleWikiURL = new JPanel();
		tabbedPane.addTab("Single Wiki URL", null, pnlSingleWikiURL, null);

		JLabel lblPageLanguage = new JLabel("Page Language :");
		lblPageLanguage.setBounds(292, 52, 102, 22);

		JButton btnWikiURL = new JButton("Define Language");
		btnWikiURL.setBounds(96, 52, 131, 23);

		txtWikiURL = new JTextField();
		txtWikiURL.setBounds(96, 11, 513, 20);
		txtWikiURL.setColumns(10);

		JLabel lblResult = new JLabel("-----");
		lblResult.setBounds(413, 56, 114, 14);
		pnlSingleWikiURL.setLayout(null);

		JLabel lblWikiUrl = new JLabel("Wikipedia URL");
		lblWikiUrl.setBounds(10, 14, 118, 14);
		pnlSingleWikiURL.add(lblWikiUrl);
		pnlSingleWikiURL.add(txtWikiURL);
		pnlSingleWikiURL.add(btnWikiURL);
		pnlSingleWikiURL.add(lblPageLanguage);
		pnlSingleWikiURL.add(lblResult);

		JScrollPane scrollPane = new JScrollPane();
		scrollPane.setBounds(10, 97, 599, 245);
		pnlSingleWikiURL.add(scrollPane);

		JTextArea textArea = new JTextArea();
		textArea.setWrapStyleWord(true);
		textArea.setLineWrap(true);
		textArea.setEditable(false);
		scrollPane.setViewportView(textArea);

		JPanel panel = new JPanel();
		tabbedPane.addTab("Wikipedia URL File", null, panel, null);
		panel.setLayout(null);

		JButton btnChooseFile = new JButton("Choose File");
		btnChooseFile.setBounds(10, 11, 105, 23);
		panel.add(btnChooseFile);

		textFieldFileLocation = new JTextField();
		textFieldFileLocation.setBounds(125, 12, 484, 20);
		panel.add(textFieldFileLocation);
		textFieldFileLocation.setColumns(10);
		textFieldFileLocation.setEditable(false);

		JScrollPane scrollPane_1 = new JScrollPane();
		scrollPane_1.setBounds(10, 47, 599, 295);
		panel.add(scrollPane_1);

		table = new JTable();
		scrollPane_1.setViewportView(table);

		Object[] coloumn = {"URL", "LANGUAGE"};
		DefaultTableModel model = new DefaultTableModel();
		model.setColumnIdentifiers(coloumn);
		table.setModel(model);
		table.setAutoResizeMode(JTable.AUTO_RESIZE_OFF);
		table.getColumnModel().getColumn(0).setPreferredWidth(400);
		table.getColumnModel().getColumn(0).setResizable(false);
		table.getColumnModel().getColumn(1).setPreferredWidth(196);
		table.getColumnModel().getColumn(1).setResizable(false);

		JPanel panel_1 = new JPanel();
		tabbedPane.addTab("Text File", null, panel_1, null);
		panel_1.setLayout(null);

		JButton btnTextFile = new JButton("Choose File");
		btnTextFile.setBounds(12, 11, 102, 23);
		panel_1.add(btnTextFile);

		JLabel lblFilesLanguage = new JLabel("File's Language :");
		lblFilesLanguage.setBounds(124, 43, 96, 14);
		panel_1.add(lblFilesLanguage);

		JTextArea textArea_1 = new JTextArea();
		textArea_1.setWrapStyleWord(true);
		textArea_1.setLineWrap(true);
		textArea_1.setEditable(false);
		textArea_1.setBounds(12, 68, 597, 274);
		panel_1.add(textArea_1);

		textField = new JTextField();
		textField.setBounds(124, 12, 485, 20);
		panel_1.add(textField);
		textField.setColumns(10);
		textField.setEditable(false);

		JLabel lblTextFile = new JLabel("-----");
		lblTextFile.setBounds(230, 43, 46, 14);
		panel_1.add(lblTextFile);

		JLabel label = new JLabel("");
		label.setBounds(251, 51, 46, 14);
		
		btnTextFile.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				//open file dialog
				fileChooser.showOpenDialog(null);
				//create instance for TextFileReader
				TextFileReader textFileReader = new TextFileReader();
				try {
					//read content from the chosen file
					ArrayList<String> text = textFileReader.getText(
							fileChooser.getSelectedFile().getAbsolutePath());
					//set result to label
					lblTextFile.setText(languageIdentifier.whichLanguage(text));
					//read content from the file and paste to textarea
					BufferedReader br = new BufferedReader(new InputStreamReader(
							new FileInputStream(fileChooser.getSelectedFile().getAbsolutePath()), "UTF-8"));
					String line,string = "";
					while ((line = br.readLine()) != null)  {
						string +=line;
					}
					textArea_1.setText(string);
					textArea_1.setCaretPosition(0);
					br.close();
					textField.setText(fileChooser.getSelectedFile().getAbsolutePath());
				} catch (IOException ex) {
					JOptionPane.showMessageDialog(frame, 
							"Something went wrong ! Please check the entered URL !", 
                            "ERROR",JOptionPane.WARNING_MESSAGE);
					ex.printStackTrace();
				}
			}
		});
		
		// Click event for the Wikipedia URL File panel button
		btnChooseFile.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				//open file dialog
				fileChooser.showOpenDialog(null);
				//WikipediaURLTextFile wikipediaURLTextFile = new WikipediaURLTextFile();
				MultipleTextSources multipleTextSources = new MultipleTextSources();
				try {
					// get the pages URL's located in the chosen file
					ArrayList<ArrayList<String>> list = multipleTextSources.getContent(
							fileChooser.getSelectedFile());
					// open the file to add the URLs to the table
					BufferedReader br = new BufferedReader(new InputStreamReader(
							new FileInputStream(fileChooser.getSelectedFile().getAbsolutePath()), "UTF-8")); 
					// iterate over rseult array for the chosen URL file 
					for (ArrayList<String> arrayList : list) {
						Object[] row = new Object[2];
						// add the URLs to the table
						row[0] = br.readLine();
						row[1]= languageIdentifier.whichLanguage(arrayList);
						model.addRow(row);
					}
					br.close();
				} catch (IOException ex) {
					JOptionPane.showMessageDialog(frame, 
							"Something went wrong ! Please check the chosen file !", 
                            "ERROR",JOptionPane.WARNING_MESSAGE);
					ex.printStackTrace();
				}
			}
		});
		
		// Click event for the Single Wikipedia URL panel button
		btnWikiURL.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				// Create instance for WikipediaAdapter
				WikipediaAdapter wikipediaAdapter = new WikipediaAdapter();
				try {
					//Get the content from Wikipedia
					ArrayList<String> plainText = wikipediaAdapter.getText(txtWikiURL.getText());
					lblResult.setText(languageIdentifier.whichLanguage(plainText));
					//Get content from Wkipedia and paste to text area
					WikipediaConnector wikipediaConnector = new WikipediaConnector();
					textArea.setText(wikipediaConnector.getContent(new URL(txtWikiURL.getText()))
							+scrollPane.getVerticalScrollBar().getValue());
					//set scrollbar value to beginning
					textArea.setCaretPosition(0);
				} catch (org.jsoup.HttpStatusException ex) {					
					JOptionPane.showMessageDialog(frame, "Please check the entered URL ", 
                            "ERROR",JOptionPane.WARNING_MESSAGE);
					ex.printStackTrace();
				} catch (java.net.SocketTimeoutException ex) {
					JOptionPane.showMessageDialog(frame, "Please check your internet connection !", 
                            "ERROR",JOptionPane.WARNING_MESSAGE);
					ex.printStackTrace();
				} catch (java.net.MalformedURLException ex) {
					JOptionPane.showMessageDialog(frame, "Please check the entered URL !", 
                            "ERROR",JOptionPane.WARNING_MESSAGE);
					ex.printStackTrace();
				} catch (IOException ex) {
					JOptionPane.showMessageDialog(frame, "Something went wrong !", 
                            "ERROR",JOptionPane.WARNING_MESSAGE);
					ex.printStackTrace();
				}
			}
		});
	}
}