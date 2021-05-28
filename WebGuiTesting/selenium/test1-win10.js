const {Builder, By, Key, until} = require('selenium-webdriver');
const firefox = require('selenium-webdriver/firefox');

(async function example() {
  let options = new firefox.Options().setBinary('C:\\Program Files\\Mozilla Firefox\\Firefox.exe');
  let driver = await new Builder().forBrowser('firefox').setFirefoxOptions(options).build();

  // let driver = await new Builder().forBrowser('firefox').build();
  // let driver = webdriver.Firefox(executable_path= 'C:\\PortableApps\\FirefoxPortable\\FirefoxPortable.exe', firefox_options=options);

  try {
    await driver.get('http://bis-testing.local/');

    await driver.findElement(By.linkText('About')).click();
    await driver.wait(until.titleIs('Over deze website'), 1000);

    await driver.findElement(By.linkText('Home')).click();
    await driver.wait(until.titleIs('Welkom!'), 1000);

    await driver.findElement(By.linkText('Credits')).click();
    await driver.wait(until.titleIs('Credits'), 1000);

    await driver.findElement(By.linkText('Contact')).click();
    await driver.wait(until.titleIs('Contact'), 1000);

    await driver.findElement(By.name('Naam')).sendKeys("Martin Molema", Key.RETURN);
    await driver.wait(until.titleIs('Dank u!'), 1000);

  } finally {
    await driver.quit();
  }
})();
