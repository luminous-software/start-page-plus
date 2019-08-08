# Developer News

*Bring back Developer News!*

![Version][version-badge-url]
![Installs][installs-badge-url]
![Rating][rating-badge-url]
[![License][license-badge]][license-url]
[![Donate][paypal-badge]](https://www.paypal.me/yannduran/5)

[version-badge-url]: http://vsmarketplacebadge.apphb.com/version-short/YannDuran.StartPage.svg?label=version&colorB=7E57C2&style=flat-square
[installs-badge-url]: http://vsmarketplacebadge.apphb.com/installs-short/YannDuran.StartPage.svg?colorB=7E57C2&style=flat-square
[rating-badge-url]: http://vsmarketplacebadge.apphb.com/rating-short/YannDuran.StartPage.svg?colorB=7E57C2&style=flat-square
[license-badge]: https://img.shields.io/badge/license-MIT-7E57C2.svg?style=flat-square
[license-url]: https://github.com/luminous-software/developer-news/blob/master/LICENSE
[paypal-badge]: https://img.shields.io/badge/donate-paypal-green.svg?style=flat-square
[paypal-url]: https://www.paypal.me/yannduran/10

You can download this extension [from the Visual Studio Marketplace][marketplace-url]

[marketplace-url]: https://marketplace.visualstudio.com/items?itemName=YannDuran.StartPage

---

## Where's My Developer News?

When Visual Studio 2019 was released, many developers were dismayed to find that the _Start Page_ had been completely
replaced by the new _Start Window_ (a big **modal** dialog, which had no room for _Developer News_).

### Community Outcry

There was a **huge** outpouring of disatification on the [Developer Community forum][developer-community-forum-url] that
not only had the _Start Page_ been taken away (& _Developer News_ with it), but we were left with **no way to get _Developer News_**
in Visual Studio 2019 anymore.

[developer-community-forum-url]: https://developercommunity.visualstudio.com/idea/399833/bring-back-the-developer-news-on-startup.html

### Microsoft's Response

Increduously, Microsoft's response was to simply add a watered-down version of the old *Developer News* to the
[right-hand column of the Visual Studio installer][microsoft-announcement-url].

But nobody wants to have to open the installer just to view their morning developer news.
They want to see it as soon as they open Visual Studio, as they had done for years.

![VS Installer](docs-source/assets/images/installer.png)

[microsoft-announcement-url]: https://developercommunity.visualstudio.com/comments/469066/view.html

### Forum Announcement

I [wrote a post in the Developer Community Forum][my-announcement-url] to announce that 
"_I've decided to write a little extension to add a tool window to display the missing Developer News,
either as a stop-gap until MS decide to see sense, or to use instead for the future going forward if they don't_".

[my-announcement-url]: https://developercommunity.visualstudio.com/comments/513534/view.html

### Start Page Is Back (for now)

Another developer, [Jan Kučera][jan-kučera-url], released his [Start Page on Startup][start-page-on-startup-url]
extension to restore access to the _VS 2017 Start Page_. The code for the _Start Page_ still existed in VS 2019
but had been "hidden" by Microsoft.

The original _Developer News_ feed was of course also restored, but it was broken and there was no UI for us to be able to "fix" it.
However, after a few tweaks to the extension Jan had the feed up and running again.

The only problem is that Jan's extension relies on displaying the _Start Page_ that has been "hidden" in VS 2019.
This page's code, as a [Microsoft employee reminded us][microsoft-employee-url], "_is subject to **vanish at anytime**_".

[jan-kučera-url]: https://developercommunity.visualstudio.com/users/863/047cb52a-d0ac-4677-9337-118da1c525e4.html
[start-page-on-startup-url]: https://marketplace.visualstudio.com/items?itemName=JanKucera.StartPageOnStartup
[microsoft-employee-url]: https://developercommunity.visualstudio.com/comments/513807/view.html

## Developer News Is Back!

The [Developer News][developer-news-url] extension adds a new **dockable tool window** to display the same developer news feed
that VS 2017's _Start Page_ used to provide.

However it doesn't actually rely on the RSS feed control that's embedded in VS 2019's hidden _Start Page_ implementation.
So when Microsoft removes the code for the _Start Page_, and I do believe that they'll remove it at some point,
any extensions that rely on that code will cease to function.

Unless of course they decide to give us back the _Start Page_
as so many of us have been asking for in [Start Page: Please give it back!][give-back-start-page-url]

_Developer News_ has been written **from the ground up** and will therefore **not** be affected.

To open the new _Developer News_ window:

- select **View** | **Developer News**

![Dev News](docs-source/assets/images/dev-news.png)

The old _Developer News_ feed is just the **first** developer-focused feed to be added to the new _Developer News_ window,
with **more feeds to come** in the near future (check out [the roadmap][roadmap-url] for more details).

[developer-news-url]: https://marketplace.visualstudio.com/items?itemName=YannDuran.StartPage
[roadmap-url]: https://luminous-software.solutions/developer-news/roadmap
[give-back-start-page-url]: https://developercommunity.visualstudio.com/idea/434456/start-page-please-give-it-back.html

## More Information

You can read more about _Developer News_ on its website:

[Overview][website-url] **|** [Getting Started][getting-started-url] **|** [Features][features-url] **|** [Changelog][changelog-url] **|** [Roadmap][roadmap-url]

[website-url]: https://luminous-software.solutions/developer-news
[getting-started-url]: https://luminous-software.solutions/developer-news/getting-started
[features-url]: https://luminous-software.solutions/developer-news/features
[changelog-url]: https://luminous-software.solutions/developer-news/changelog
[roadmap-url]: https://luminous-software.solutions/developer-news/roadmap

## Support the Project

If *Developer News* has saved you time and hassle, please come back and show your support:

  - you could [***rate *Developer News****][rate-or-review-url] (only takes a couple of seconds)
  - or [***review *Developer News****][rate-or-review-url] (help others benefit from your experience)
  - or [***shout me a coke***](https://www.paypal.me/yannduran/5) (I don't drink coffee or beer lol)

[rate-or-review-url]: https://marketplace.visualstudio.com/items?itemName=YannDuran.StartPage#review-details

## Contribution Guidelines

Check out the [contribution guidelines][contributing-url]
if you'd like to contribute to this project.

[contributing-url]: https://github.com/luminous-software/developer-news/blob/master/.github/CONTRIBUTING.md

## License

This project is licensed under the MIT License - [click here][license-url] for details

---

<div style="text-align: center">
    <img src="art/lss-vsip.png"/>
</div>
