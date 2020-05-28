For a list of known issues go to the [Known Issues][known-issues-url]
page on the [Start Page+][start-page-plus-url] website.

[start-page-plus-url]: https://luminous-software.solutions/start-page-plus
[known-issues-url]: https://luminous-software.solutions/start-page-plus/known-issues

## Releases

### v1.0 - 2020-05-28

#### Added
  - the ability to **pin**/**unpin** items in the *Recent Items* list [(GitHub Issue #21)][github-issue-21]
  - the ability to **remove** items from the *Recent Items* list [(GitHub Issue #35)][github-issue-35]
  - the ability to copy an item's path to the Windows clipboard
  - a **Restart Visual Studio** option to *Get Started* column [(GitHub Issue #20)][github-issue-20]
    - also **Restart Visual Studio as Administrator**
  - a **Start Page+ Options** command to open `Tools` | `Options` | `Start Page+` | `General`
    - found in `Tools` | `Options`
  - a **Changelog** button to *Get Started* column to open the website's changelog page
  - an **Options** button to *Get Started* column to open `Tools` | `Options` | `Start Page+` | `General`
  - a **Max Width** setting [(GitHub Issue #32)][github-issue-32]
    - replaces fixed width of 1175
  - a **Recent Items to Display** setting
  - a **News Items to Display** setting
  - the ability to **collapse**/**expand** the group heading in the *Recent Items* list
  - new options pages (**Features**, **Settings**)
  - a **Hide Extensions** setting to hide a project/solution's extension in *Recent Items* list
  - a functional **Pin** button to *Recent Items*
  - an **Unpin** button to *Recent Items*
  - an auto-refresh to *Recent Items* after clicking on an item

[github-issue-20]: https://github.com/luminous-software/start-page-plus/issues/20
[github-issue-21]: https://github.com/luminous-software/start-page-plus/issues/21
[github-issue-35]: https://github.com/luminous-software/start-page-plus/issues/35
[github-issue-32]: https://github.com/luminous-software/start-page-plus/issues/32

#### Removed
  - the **Continue Without Code** item from the *Get Started* column [(GitHub Issue #19)][github-issue-19]

[github-issue-19]: https://github.com/luminous-software/start-page-plus/issues/19

#### Changed
  - the website page that clicking on the version number takes you to
    - used to go to the *Changelog* page
    - now goes to the website's *Overview* page
  - the position of the date in the *Recent Items* list to give more space for the
project/solution/folder path

#### Fixed
  - '*Recent Item Timeframes Disappear When Refresh is Clicked*' [(GitHub Issue #5)][github-issue-5]
  - '*Be able to start typing in the Recent Item Filter Box with out having to click in it first*' [(GitHub Issue #6)][github-issue-6]
  - '*PackageClass did not load correctly' (VS 2017)* [(GitHub Issue #8)][github-issue-8]
  - '*Window is not docked on first ever use*' ([GitHub Issue #14][github-issue-14])
  - '*Images in Start tab have the wrong background color in some themes*' [(GitHub Issue #22)][github-issue-22]
  - '*Projects with space in the name not opening*' [(GitHub Issue #23)][github-issue-23]
  - '*Dates have a fixed AU/UK format in the Recent Items list*' [(GitHub Issue #24)][github-issue-24]
  - '*Only Folder, Solution, and C# Project currently have icons in Recent Items*' [(GitHub Issue #26)][github-issue-26]
  - '_VS stopped responding for 28 seconds_' [(Github Issue #31)][github-issue-31]
  - '*Recent Item accessed date not updating*' [(Github Issue #37)][github-issue-37]
  - *Start Page+* is not respecting the *Open Links in VS* option

[github-issue-5]: https://github.com/luminous-software/start-page-plus/issues/5
[github-issue-6]: https://github.com/luminous-software/start-page-plus/issues/6
[github-issue-8]: https://github.com/luminous-software/start-page-plus/issues/8
[github-issue-14]: https://github.com/luminous-software/start-page-plus/issues/14
[github-issue-22]: https://github.com/luminous-software/start-page-plus/issues/22
[github-issue-23]: https://github.com/luminous-software/start-page-plus/issues/23
[github-issue-24]: https://github.com/luminous-software/start-page-plus/issues/24
[github-issue-26]: https://github.com/luminous-software/start-page-plus/issues/26
[github-issue-31]: https://github.com/luminous-software/start-page-plus/issues/31
[github-issue-37]: https://github.com/luminous-software/start-page-plus/issues/37

## Preview Releases

### v0.14.3 - 2019-10-02

- Preview 3
  - implemented a new & improved, more consistent color scheme (hopefully)

### v0.13.2 - 2019-09-30

- Preview 2
  - added
    - filtering in *Recent Items*
    - *clear filter* button
    - descriptions for tabs that have yet to be implemented
    - easy-to-find, but non-intrusive version number to *Start Actions*
        - clicking on the link opens the *Start Page+* website's changelog page
  - improved
    - unreadable color combinations in the *Blue* theme ([GitHub Issue #2][github-issue-2])
      - thanks to [@MagicAndre1981][MagicAndre1981], [@sevanmarc][sevanmarc]
  - fixed
    - 'Missing prerequisites for VS 2017' ([GitHub Issue #8][github-issue-8])
    - 'Wrong icon shown in _View_ | _Start Page+_' ([GitHub Issue #11][github-issue-11])
    - 'NRE when there are no _recent items_' ([GitHub Issue #12][github-issue-12])
      - thanks to [@MagicAndre1981][MagicAndre1981], [@sevanmarc][sevanmarc]

[github-issue-2]: https://github.com/luminous-software/start-page-plus/issues/2
[github-issue-8]: https://github.com/luminous-software/start-page-plus/issues/8
[github-issue-11]: https://github.com/luminous-software/start-page-plus/issues/11
[github-issue-12]: https://github.com/luminous-software/start-page-plus/issues/12
[sevanmarc]: https://github.com/sevanmarc
[MagicAndre1981]: https://github.com/MagicAndre1981


### v0.12.1 - 2019-09-15

- Preview 1
  - implemented basic *Recent Items*
  - implemented *Start Actions*
  - implemented *Developer News*

## Internal Releases

### v0.1 - v0.11

- added `StartPagePlusWindow` (tool window)
- added `MainView`
- added `StartView`
  - added `RecentItemsView`
  - added `StartActionsView`
  - added `NewsItemsView`
- added temporary `FavoritesView`
- added temporary `CreateView`
- added temporary `NewsView`
- added `GeneralOptions` page
- added *View* | *Start Page+*
- added *Tools* | *Options*