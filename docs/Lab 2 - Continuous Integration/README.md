Previous lab: [Lab 1 - Source control](../Lab%201%20-%20Source%20control/README.md)

# Lab 2 - Continuous Integration (CI)

Duration: 20 min

![Develop - Build - Overview](./imgs/Develop-Build-Overview.PNG)

The goal of this lab is to configure the different steps of the *Continuous Integration (CI)* process for a given web app through a VSTS Build Definition. The basic concepts of a CI phase is to expose different artifacts which will be used during the next Continuous Delivery (CD) phase. Finally, you will trigger 2 builds to observe the process: One manually initiated and one auto-triggered by a commit. 

Best practices highlighted:

- Import Build Definition from YAML file ("as code") provided by the "Ops" team
- Integrate unit tests during the CI process
- Trigger CI at each commit into master branch
- Validate code on feature-branch by pre-merging and building PR changes
- Do code review through PR (comments, rejection, etc.)
- Automatically create work items on build failures as bug in the backlog
- Generate artifacts to be reused in a separate Continuous Delivery (CD) process
- Automate communications with your teammates through Slack notifications

You will go through 3 main sections in this lab:

- Create/Import the VSTS Build definition and expose the `app`, `infra` and `ui-tests` artifact
- Update the `master` branch policies to validate code by pre-merging and building PR changes
- Fix the unit test issue by submitting a new pull request

## Create the VSTS Build definition and expose the "app", "infra" and "ui-tests" artifacts

1. Open a **new web browser instance in Incognito, Private or InPrivate mode** to avoid any signed-in session conflict.
2. Go to your VSTS account `https://<your-vsts-account>.visualstudio.com` and open your VSTS project for this lab.
  - *Note: with the step below you may need to activate the `Build YAML definitions` preview features for your VSTS account.*
3. Navigate to **Build and Release** > **Build** tab and click on the **New definition** or **New** button and select the template: `Config as code` > `YAML` and click on the **Apply** button:

![VSTSBuild - New Definition](./imgs/VSTSBuild-NewDefinition.PNG)

4. You will land on the **Yaml** > **Process** step:
  - Change the **Name** field to `CI`
  - Choose the correct `Hosted VS2017` value for the **Agent queue** field (otherwise you will get an error while saving and queueing your build)
  - Set the **Yaml path** field value to `src/MainWebApplication/MainWebApplicationVsts/CI.yml`
    - *Note: you could look at this file to see how is defined the Build definition as code.*

![VSTSBuild - Setup Definition](./imgs/VSTSBuild-SetupDefinition.PNG)

5. Navigate to the **Triggers** tab of this Build definition page and enable the **Trigger status** of the **Continuous Integration** section.

![VSTSBuild - CI Trigger](./imgs/VSTSBuild-CITrigger.PNG)

6. *(You could skip this step because YAML Definition doesn't support yet it)* Navigate to the **Options** tab of this Build definition page and enable the **Create work item on failure** and **Automatically link new work in this build** options.

![VSTSBuild - Create WorkItem On Failure](./imgs/VSTSBuild-CreateWorkItemOnFailure.PNG)

7. Click on the **Save & queue** toolbar button (top right hand corner). The **Save build definition and queue** will popup and just click on the **Save & queue** button.

8. At this point the build has been started. After ~2 min this build should failed because of a unit test failure:

![VSTSBuild - First Build Failed](./imgs/VSTSBuild-FirstBuildFailed.PNG)

*Note: If the notifications triggers in the previous lab were completed successfully, you should be able to see the 2 different notifications related to this failure in Slack: 1 for the Build failed in the `#build` channel and 1 other for the Work Item created in the `#work` channel.*

## Update the "master" branch policies to validate code by pre-merging and building PR changes

9. Now we have a build definition created, let's adjust the `master` branch policies to reinforce quality check while creating and managing new Pull Request on branches; Go to the `master` branch policies page (as you did with the [previous lab](../Lab%201%20-%20Source%20control/README.md)) and click on the **Add build policy** to then select the `CI` Build definition we just created. Click on **Save** on the pop-up:

![VSTSCode - Build Policy On PR](./imgs/VSTSCode-BuildPolicyOnPR.PNG)

## Fix the unit test issue by submitting a new pull request

10. Go to the VSTS **Work** main tab to create a new branch based on the `master` branch. Click on **New branch** action and name it as `fix-add-method` and then click on the **Create branch** button:

![VSTSCode  - Create New Branch](./imgs/VSTSCode-CreateNewBranch.PNG)

11. Navigate to the `src/MainWebApplication/MainWebApplication/Services/AdditionService.cs` file on this `fix-add-method` branch. Click on the **Edit** button (top right hand corner) and then update the line 7 by replacing `return y + y;` by `return x + y;` (Yeah, big mistake! ;)). Click on the **Commit...** button (top right hand corner again) and on the **Commit** button on the *Commit* dialog.

![VSTSCode - Edit And Commit Code](./imgs/VSTSCode-EditAndCommitCode.PNG)

12. You will be invited to create a Pull Request based on this commit on this branch. Let's proceed to land on the **New Pull Request** page:

![VSTSCode - Create Pull Request](./imgs/VSTSCode-CreatePullRequest.PNG)

13. As a PR/code review, comment the line updated on the right hand side:

![VSTSCode - PR Code Review](./imgs/VSTSCode-PRCodeReview.PNG)

14. On the **Overview** tab of this PR you should see the status of the current policies: 1 Build should be in progress and **Not all comments resolved**. By waiting the end of the current build, let's **Resolve** the comment:

![VSTSCode - Pull Request Overview](./imgs/VSTSCode-PullRequestOverview.PNG)

15. Once the Build is completed successfully (now that you have resolved the unit test issue in this PR, the build should pass), you will be able to **Complete** this PR:

![VSTSCode - Complete Pull Request](./imgs/VSTSCode-CompletePullRequest.PNG)

20. A new build will be triggered after the merge into `master` branch, it should be completed successfully and you should see the 3 artifacts below. Furthermore, you should see new Slack notifications (Code pushed + Build completed) as well.

![VSTSBuild - Artifacts](./imgs/VSTSBuild-Artifacts.PNG)

You are now all set for this lab. Let's see how the 3 artifacts of these CI will be used with the next lab during the CD process.

Next lab: [Lab 3 - Continuous Delivery](../Lab%203%20-%20Continuous%20Delivery/README.md)