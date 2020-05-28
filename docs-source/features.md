To display the new *Start Page+* window:

- click **View** | **Start Page+**

## Recent Items

The *Recent Items* list brings back the ability to filter the list of recent items,
and the grouping by timeframe that we had in VS 2017.

![Recent Items](assets/images/recent-items.png)

### Live Filtering

Type a name, or a partial name, into the filter box above the list to display just the matching items
as you type.

Click the **X** in the filter box to start again, or to go back to the full list of items.

### Collapse/Expand Timeframes

Each timeframe group can be collapsed or expanded by clicking anywhere on the group name.
This can come in handy if you want to view items that are currently not being displayed
without having to scroll all the way down.

### Pin/Unpin An Item

Right-click an ***unpinned*** item in the *Recent Items* list, and select *Pin item* to ***pin*** it.
Or click on the icon to the right of the date.

Right-click on a ***pinned*** item in the *Recent Items* list, and select *Unpin item* to ***unpin*** it.
Or click on the icon to the right of the date.

### Remove An Item

Right-click any item in the *Recent Items* list, and select *Remove item* to remove it.

### Copy An Item's Path

Right-click any item in the *Recent Items* list, and select *Copy item path* to copy it
path to the Windows clipboard. You can then paste it anywhere you need to.

### Refresh

When you select the number of items to display, you'll need to click the *Refresh* button to see
the change.
It's also a quick way to expand all of the timeframe groups at once.

## Start Actions

The *Start Actions* list gives new users a simplified way to get to their code, the same as in VS 2019's
*Start Window*. Plus a few extras.

![Start Actions](assets/images/start-actions.png)

### Clone Or Checkout Code

Quickly get code from an online repository by entering the repository location.
You can also browse GitHub or Azure DevOps repositories from here,
which will take you to the *Connect* dialog.

### Open A Local Folder

Open any folder on your local machine, or on a network share.
Here *local* basically just means '*not in the cloud*'.

### Open A Project Or Solution

A quick way to get to the *Open Project/Solution* dialog without having to use `File` | `Open` | `Project/Solution`.

### Create A New Project

A quick way to get to the *New Project* dialog without having to use `File` | `New` | `Project`.

### Restart Visual Studio

Any time you need to restart Visual Studio you can do it from the *Start Page+* window in just one click.
No need to close and re-open Visual Studio manually.

### Restart Visual Studio As Administrator

You can also restart Visual Studio as Administrator without having to you through the hassle of finding
and right-clcking a Visual Studio shortcut etc.

Note: if you launch Visual Studio as Administrator, you can't get back to a non-elevated session by
clicking on *Restart Visual Studio*.
There doesn't seem to be a programmatic way to force an elevated session to restart as a normal session.

### Changelog Button

With just a single-click you can see what's changed in the new version of *Start Page+*.

### Version Number

This is a subtle way of being able to see the version number of the currently installed version of
*Start Page+*.

Clicking on the version number will open the website's Overview page.
On there you can see what the latest available version of *Start Page+* is at the top of the page.

### Options Button

Clicking on the *Options* button is a quick way to get to the *Start Page+* options page without
having to use `Tools` | `Options` | `Start Page+`.

## Developer News

The *Developer News* feed brings back VS 2017's handy list of Microsoft developer-related news items that was removed from
VS 2019.
I don't know how many times I've seen something that interests me that I might have missed if I hadn't seen it on my
start page.

![Developer News](assets/images/developer-news.png)

### Open Links in VS or Browser

By default the items open right in VS itself, rather than switching to the default browser.
Personally, I prefer having to switch applications as little as possible.
When I'm working in Visual Studio, I prefer to stay in Visual Studio, and not have my attention derailed by having
to switch to a different application, and then back again to Visual Studio.

However, for those people who prefer links to be opened in their default browser,
there's an option to change Start Page+'s behavior to do just that.

### News Items to Display

You can decide how many news items you want displayed in your *Developer News* list,
by clicking on the *Options* button, then clicking on the *Settings* page.

## Refresh

There is currently no auto-refresh for *Developer News*, so you'll have to click *Refresh* to
check if you have the latest available news items from Microsoft.

ALso, when you select the number of items to display, you'll need to click the *Refresh* button
to see the change.

## General Options

![General Options](assets/images/options-general.png)

### Enable 'Start Page+'

This setting allows _Start Page+_ to be *turned off*, without having to uninstall the _Start Page+_ extension,
which would require you to exit **all** instances of Visual Studio, wait while the _VSIX installer_ does its thing,
then open Visual Studio again.

If you're worried about the _Start Page+_ extension still using resources, once you enable this setting,
the _View_ | _Start Page+_ and the _Tools_ | _Start Page+ Options_ menu items will no longer be available,
so the extension will have no need to be loaded.

However, instances of any tool window are never _destroyed_ when they're _closed_, so until you close Visual Studio there will
be some remaining resources being used. But the next time you start Visual Studio, there'll be no way to open
the _Start Page+_ window, so the extension will not need to be loaded.

### Version Number

This setting simply displays the version number of _Start Page+_ that's currently installed.

## Feature Options

![Feature Options](assets/images/options-features.png)

### Enable 'Open Links in VS'

When this setting is set to `true`, any clicked item that opens a web page will be opened in a browser window
**inside** of Visual Studio.

When set to `false`, clicked items that open a web page will be opened in your default browser.

### Enable 'Start Page+ Options'

When this setting is set to `true` a 'Start Page+ Options' command is added to the `Tools` | `Options` menu.

## Setting Options

![Feature Options](assets/images/options-settings.png)

### Hide Recent Item Extensions

This setting allows to hide a project/solution's extension (.csproj, .sln) in the *Recent Items* list.


### Max Width

The default value of 1175 should be fine for everyone, regardless of your monitor resolution.
However if you'd like the contents of the _Start Page+_ window to be wider or narrower,

### News Items to Display

This setting will allow you to determine how many items are displayed in the *Developer News* list.

The default value is 10.

### Recent Items to Display

This setting will allow you to determine how many items are displayed in the *Recent Item* list.

The default value is 50.

### Show Start Tab Title

By default, the *Start* tab displays a title. This setting will allow you to hide it.

The default value is `true`.