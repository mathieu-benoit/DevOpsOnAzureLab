Previous lab: [Lab 2 - Continuous Integration](../Lab%202%20-%20Continuous%20Integration/README.md)

# Lab 3 - Continuous Delivery

Duration: 20 min

![Delivery - Overview](./imgs/Delivery-Overview.PNG)

The goal of this lab is to ... 

Best practices highlighted:

- Use a dedicated version of the CI's artifacts (latest by default)
- Use Azure ARM Templates as Infrastructue-as-code exposed by the "Ops" team
- Store settings on the server - defined in the ARM Templates
- Run UITests
- Auto-trigger the CD when the associated CI is completed
- Automate the communication with your teammates through Slack notifications

You will go through 4 main sections in this lab:

- Create a Release definition
- Deploy the infrastructure and the app
- Run the UITests

## Create the Release definition to deploy the "app" artifact in DEV environment

1. Go to your VSTS account `https://<yourvstsaccount.visualstudio.com` and open your VSTS project for this lab
2. Navigate to the "Release" sub-tab of the "Build and Release" tab and click on the "Import" button on the top right hand corner to import the file below. Copy/paste this path into the "File name" field and then click on "Open" and finally "Import":

`
https://raw.githubusercontent.com/mathieu-benoit/DevOpsOnAzureLab/master/docs/Lab%203%20-%20Continuous%20Delivery/CD.json
`

![VSTSBuild - New Definition](./imgs/VSTSBuild-NewDefinition.PNG)

3. After the import, rename the Release definition as `CD` and go to the "Tasks" tab of this Release definition and apply the actions below for each Environment: `DEV`, `QA-staging`, `QA`, `Delete QA-staging and QA` and `Rollback QA`:

![VSTSBuild - New Definition](./imgs/VSTSBuild-NewDefinition.PNG)

- Set the "Agent queue" of the "Run on agent" step to `Hosted VS2017`
- Set the "Azure subscription" of the first step "Deployment process" to `Azure Paas - Connection`

4. Go to the "Pipeline" tab of this Release definition and add our "CI" Build as artifact:

![VSTSBuild - New Definition](./imgs/VSTSBuild-NewDefinition.PNG)

5. On this artifact let's enable the "Continuous deployment trigger":

![VSTSBuild - New Definition](./imgs/VSTSBuild-NewDefinition.PNG)

6. Go to the "Variables" of this Release definition and change the value of the `AppServiceName` variable to your correct number `atq2017devopsXX`

![VSTSBuild - New Definition](./imgs/VSTSBuild-NewDefinition.PNG)

7. Let's trigger a Release now we are ready ...

## Let's customize a bit this pipeline

Manual approval

Rollback if deployed link

Production link with QA duplication

## Browse the Azure resources

Next lab: [Lab 4 - Monitor and Learn](../Lab%204%20-%20Monitor%20and%20Learn/README.md)