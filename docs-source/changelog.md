## Preview Releases

For a list of known issues go to the [Known Issues][known-issues-url]
page on the [Start Page+][start-page-plus-url] website.

[start-page-plus-url]: https://luminous-software.solutions/start-page-plus
[known-issues-url]: https://luminous-software.solutions/start-page-plus/known-issues

### v0.15.4 - 2019-10-??

  - Preview 4
    - fixed 'Window is not docked on first ever use ([GitHub Issue #14][github-issue-14])
      - hopefully this does fix this issue, it did when I tested it
    - fixed 'PackageClass did not load correctly (VS 2017)' [(GHI #8)][github-issue-8]
    - fixed 'Projects with space in the name not opening' [(GHI #23)][github-issue-23]
    - fixed 'Dates have a fixed AU/UK format in the Recent Items list' [(GHI #24)][github-issue-24]

[github-issue-8]: https://github.com/luminous-software/start-page-plus/issues/8
[github-issue-14]: https://github.com/luminous-software/start-page-plus/issues/14
[github-issue-23]: https://github.com/luminous-software/start-page-plus/issues/23
[github-issue-24]: https://github.com/luminous-software/start-page-plus/issues/24

### v0.14.3 - 2019-10-02

  - Preview 3
    - implemented a new & improved, more consistent color scheme (hopefully)

### v0.13.2 - 2019-09-30

  - Preview 2
    - added filtering to *Recent Items*
    - added *clear filter* button
    - added descriptions to tabs that have yet to be implemented
    - added easy-to-find, but non-intrusive version number to *Start Actions*
        - clicking on the link opens the *Start Page+* website's changelog page
    - improved unreadable color combinations in the *Blue* theme ([GitHub Issue #2][github-issue-2])
        - thanks to [@MagicAndre1981][MagicAndre1981], [@sevanmarc][sevanmarc]
    - fixed 'Missing prerequisites for VS 2017' ([GitHub Issue #8][github-issue-8])
    - fixed 'Wrong icon shown in _View_ | _Start Page+_' ([GitHub Issue #11][github-issue-11])
    - fixed 'NRE when there are no _recent items_' ([GitHub Issue #12][github-issue-12])
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
