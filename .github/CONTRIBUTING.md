# Contributing
Looking to contribute something? Here's how you can help.

Please take a minute to review these guidelines, so that the contribution
process is easy and effective for everyone involved.

## Using the Issue Tracker

The issue tracker is the preferred channel for
[bug reports](#bug-reports),
[features requests](#feature-requests) and
[submitting pull requests](#pull-requests),
but please respect the following requests:
- Please **do not** use the issue tracker for personal support requests.
- Please try to keep the discussion on topic
- Please respect the opinions of others, even if you don't agree with them.

## Bug Reports
A bug is a _demonstrable problem_ that is caused by the code in the repository.
Good bug reports are extremely helpful, so thanks!

Guidelines for bug reports:

1. **Use the GitHub issue search** &mdash; check if the issue has already been
    reported.
2. **Check if the issue has been fixed** &mdash; try to reproduce it using the
    latest `master` branch in the repository.
3. **Isolate the problem** &mdash; ideally create a small live example.
    Uploading the project on cloud storage (OneDrive, DropBox, etc)
    or creating a sample GitHub repository is also helpful.

A good bug report shouldn't need to be chased up for more information.
Please try to be as detailed as possible.

- What's your OS version?
- What version of Visual Studio are you using?
- What steps will reproduce the issue?
- What would you expect to happen?
- What does actually happen?

All these details will make it easier to fix any potential bugs.

Example:
> Short and descriptive example bug report title
>
> A summary of the issue and the OS and Visual Studio versions in which it occurs.
>
> - OS Version: '_Windows 10 Version 1709_', or '_Windows 10 Pro Build 16299.125_'
> - VS Version: '_Visual Studio Community 2017 Version 15.5.4_'
>
> If appropriate, include the steps required to reproduce the bug.
>
> 1. This is the first step
> 2. This is the second step
> 3. Further steps, etc.
>
> `<url>` - a link to the project/file uploaded to publicly accessible cloud storage.
>
> Any other information you think is relevant to the issue being reported.
> This might include the lines of code that you have identified as causing the bug,
> and potential solutions (as well as your opinions on the likelihood of success).

## Feature Requests

Feature requests are very welcome. Be sure take a moment to find out whether your idea
fits with the scope and aims of the project.
It's up to *you* to make a strong case for the addition of your suggested feature.
Please provide as much detail and context as possible.

## Pull Requests
Good pull requests, improvements and new features are a great help.
But they should remain focused, avoiding any unrelated commits.

**Please ask first** before embarking on any significant pull request (e.g.
implementing features, refactoring code), otherwise you risk spending a lot of time
working on something that might not end up being merged into the project.

Please try to follow the [coding guidelines](#code-guidelines) used throughout the
project (same indentation, accurate comments, etc).

Using to the following process is the best way to get your work included in the project:

1. [Fork](http://help.github.com/fork-a-repo/) the project, clone your fork,
    and configure an upstream remote:

    ```bash
    # Clone your fork of the repo into the current directory
    git clone https://github.com/<your-username>/start-page.git
    # Navigate to the newly cloned directory
    cd <folder-name>

    # Assign the original repo to a remote called "upstream"
    git remote add upstream https://github.com/luminous-software/start-page.git
    ```

2. If you cloned a while ago, get the latest changes from upstream:

    ```bash
    git checkout master
    git pull upstream master
    ```

3. Create a new topic branch (in your local repository) to
    contain your feature, change, or fix:

    ```bash
    git checkout -b <topic-branch-name>
    ```

4. Commit your changes in logical chunks. Please try to follow these
    [git commit message guidelines][git-commit-message-guidelines]
    or your code is unlikely be merged into the main project.

    Use Git's [interactive rebase][git-interactive-rebase] feature
    to tidy up your commits before making them public.

    [git-commit-message-guidelines]: http://tbaggery.com/2008/04/19/a-note-about-git-commit-messages.html
    [git-interactive-rebase]: https://help.github.com/articles/interactive-rebase

5. Locally merge (or rebase) the upstream development branch into your topic branch:

    ```bash
    git pull [--rebase] upstream master
    ```

6. Push your topic branch up to your fork:

    ```bash
    git push origin <topic-branch-name>
    ```

7. [Open a Pull Request][github-pull-request-help] with a clear title and description
    against the `master` branch.

    [github-pull-request-help]: https://help.github.com/articles/using-pull-requests

## Code Guidelines

- always use the same indentation (4 spaces, not tabs)
- make sure that all warnings and errors have been addressed
