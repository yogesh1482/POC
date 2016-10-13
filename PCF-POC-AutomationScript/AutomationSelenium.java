package src.TCOE;

import org.openqa.selenium.By;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.support.ui.ExpectedCondition;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

public class OneDeliver {
	
	static String sChromeBrowserPath="C:\Project\AutomationSelenium\chromedriver_linux64/chromedriver.exe"; 
	
	public static void TC1(WebDriver driver){


	 	String sLeftHEadingName="Altfahrzeug", sExpPageTitle="TEIL EINES PAKETS";
	 	String sEnvURL="http://pcfpoc.azurewebsites.net/ ";
                
		boolean bFirefox=false;
	    
		if(bFirefox) {driver=new FirefoxDriver();}
		else{
			System.setProperty("webdriver.chrome.driver", sChromeBrowserPath);
			driver = new ChromeDriver();
		}

        WebDriverWait wait = new WebDriverWait(driver, 15);
        long startTime = System.currentTimeMillis();
        System.out.println("S1.1: Opening Browser.");
        driver.get(sEnvURL);
        WebElement elLogoHere = wait.until(ExpectedConditions.elementToBeClickable(By.cssSelector("img[src='/images/webapp.png']")));

        
        long endTime   = System.currentTimeMillis();
        long totalTime = endTime - startTime;
        totalTime=totalTime<=0 ? 0 : totalTime/1000;
        System.out.println("S1.1.1 Page title is: " + driver.getTitle()+ " Expected page title=["+sExpPageTitle+"]  validation result="+(driver.getTitle().contains(sExpPageTitle)));
        
        System.out.println("S1.2: The total time taken to load and stable=["+totalTime+"] seconds.");
        //verifythe Text
        WebElement elMainLeftLabel = wait.until(ExpectedConditions.elementToBeClickable(By.cssSelector("div#pad_left label")));
        String sActMailLeblText = elMainLeftLabel.getText();
        
        System.out.println("S1.3: ActLabel Text="+sActMailLeblText.trim()+"= Expected LAbel Text="+sLeftHEadingName+"=");
        WebElement elLeftTextBox = driver.findElement(By.cssSelector("div#pad_left input"));
        elLeftTextBox.sendKeys("222");
        
        WebElement elRightTextBox = driver.findElement(By.xpath("//label[contains(text(),'Auftrasnummer')]//following-sibling::input[1]"));
        
        String sDefaultStringRightTxtBx = elRightTextBox.getAttribute("placeholder");
        System.out.println("S1.4 Right TxtBx default string Exp=Customer Online Code= Act="+sDefaultStringRightTxtBx+"=");
        
        elRightTextBox = wait.until(ExpectedConditions.elementToBeClickable(By.xpath("//label[contains(text(),'Auftrasnummer')]//following-sibling::input[1]")));
        elRightTextBox.click();
        elRightTextBox.sendKeys("555");
        
        driver.findElement(By.partialLinkText("Ausstattungsempfehlungen")).click();	




	 	//String sHeading="TEIL EINES PAKETS"; 
        
	 	System.out.println("S2.0 Opening Page 2");

        
        String sPage2Title="TEIL EINES PAKETS";
        
        //WebElement elLogoHere = wait.until(ExpectedConditions.elementToBeClickable(By.xpath("//p[contains(text(),'"+sPage2Title+"')]")));
        System.out.println("S2.1.1 Page2  title is: " + driver.getTitle()+ " Expected page title=["+sPage2Title+"]  validation result="+(driver.getTitle().contains(sPage2Title)));
        
        
        //verifythe Text
        String sXpath="//table[@id='table1']/descendant::td[contains(text(),'Parking Pilot')]/following-sibling::td[1]/span";
        WebElement nextPage = wait.until(ExpectedConditions.elementToBeClickable(By.xpath("//td[contains(text(),'Parking Pilot')]")));
        String sTD=nextPage.getText();
        System.out.println("S2.2 Test here TD="+sTD+"= selected ");
        WebElement elDetailLink = driver.findElement(By.xpath(sXpath));
        elDetailLink.click();
        
        //verify the Heading
        String sXpathLeftPaneHEading="//div[@id='packagesDiv']/descendant::b[1]";
        WebElement elLeftPaneFirstHeading = wait.until(ExpectedConditions.elementToBeClickable(By.xpath(sXpathLeftPaneHEading)));
        System.out.println("S2.3 Detailed link clicked.");
        String ExistingHEading = elLeftPaneFirstHeading.getText();
        String sExpeString="1:Parking package with 360-degree camera";
        
        if(ExistingHEading.contains(sExpeString)){
        	System.out.println("S2.4A The expected string is matching with the actual string["+sExpeString+"]");
        }else System.out.println("S2.4B The expected string["+sExpeString+"] is not matching with the actual string["+ExistingHEading+"]");
        
        
        String sXPathSelectedItemTbl1 = "//table[@id='Package1-items']/descendant::label[contains(text(),'Parking Pilot')]";
        WebElement elSelectedItemLabel = wait.until(ExpectedConditions.elementToBeClickable(By.xpath(sXPathSelectedItemTbl1)));
        //elSelectedItemLabel.click();
        System.out.println("S2.5 Verify The status of the checkbox.");
        WebElement elSelectedChkbox = elSelectedItemLabel.findElement(By.tagName("input"));
        boolean bExpectedCheckBoxStatus=true;
        String sActualChkbxStatus=elSelectedChkbox.getAttribute("checked");
        String sActualChkbxType=elSelectedChkbox.getAttribute("type");
        System.out.println("S2.6 Checkbox validation bExpectedCheckBoxStatus["+bExpectedCheckBoxStatus+"] sActualChkbxStatus["+sActualChkbxStatus+"]");
	
	}

	//Disclaimer: This is sample and simplest Automation test script to perform a litmus test of technical feasibility. 
	//Capgemini actually have better, enhanced and matured framework to do functional automation testing for all prime commercial/open source tools.  
	//to get positive ROI in short span of time.
	//Sambodhan Dhammapathee : 20 Sept 2016
	
	 public static void main(String[] args) {
		 WebDriver driver = null; 
		 boolean bCloseBrowserAfterExecution=false;
		 try{
			 OneDeliver.TC1(driver);
		 }catch(Exception e){
			 System.out.println("S-Error: Exception="+e.getMessage()+"=");
		 }finally{
			 if(null!=driver&&bCloseBrowserAfterExecution) {
				 driver.close();
				 System.out.println("S3.0 Program completed.");
			 }
		 }
	 }

}
