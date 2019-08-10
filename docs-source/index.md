*Bring back Start Page+!*

![Version][version-badge-url]
![Installs][installs-badge-url]
![Rating][rating-badge-url]
[![License][license-badge]](https://github.com/luminous-software/start-page-plus/blob/master/LICENSE)
[![Donate][paypal-badge]](https://www.paypal.me/yannduran/5)

[version-badge-url]: http://vsmarketplacebadge.apphb.com/version-short/YannDuran.StartPagePlus.svg?label=version&colorB=7E57C2&style=flat-square
[installs-badge-url]: http://vsmarketplacebadge.apphb.com/installs-short/YannDuran.StartPagePlus.svg?colorB=7E57C2&style=flat-square
[rating-badge-url]: http://vsmarketplacebadge.apphb.com/rating-short/YannDuran.StartPagePlus.svg?colorB=7E57C2&style=flat-square
[license-badge]: https://img.shields.io/badge/license-MIT-7E57C2.svg?style=flat-square
[license-url]: https://github.com/luminous-software/start-page-plus/blob/master/LICENSE
[paypal-badge]: https://img.shields.io/badge/donate-paypal-green.svg?style=flat-square
[paypal-url]: https://www.paypal.me/yannduran/10

You can download this extension [from the Visual Studio Marketplace][marketplace-url]

[marketplace-url]: https://marketplace.visualstudio.com/items?itemName=YannDuran.StartPagePlus

---

## Bring Back Start Page!

When Visual Studio 2019 was released, many developers were dismayed to find that the _Start Page_ had been completely
replaced by the new _Start Window_ (a big **modal** dialog, which had no room for _Start Page+_).

### Community Outcry

There was a **huge** outpouring of disatification on the [Developer Community forum][developer-community-forum-url] that
not only had the _Start Page_ been taken away (& _Start Page+_ with it), but we were left with **no way to get _Start Page+_**
in Visual Studio 2019 anymore.

[developer-community-forum-url]: https://developercommunity.visualstudio.com/idea/399833/bring-back-the-start-page-plus-on-startup.html

### Microsoft's Response

![VS Installer](assets/images/installer.png)

[microsoft-announcement-url]: https://developercommunity.visualstudio.com/comments/469066/view.html

### Forum Announcement

I [wrote a post in the Developer Community Forum][my-announcement-url] to announce that
"_I've decided to write a little extension to add a tool window to display the missing Start Page+,
either as a stop-gap until MS decide to see sense, or to use instead for the future going forward if they don't_".

[my-announcement-url]: https://developercommunity.visualstudio.com/comments/513534/view.html

### Start Page Is Back (for now)

Another developer, [Jan Kučera][jan-kučera-url], released his [Start Page on Startup][start-page-on-startup-url]
extension to restore access to the _VS 2017 Start Page_. The page's code still existed in VS 2019,
but the page had been "hidden" by Microsoft.

The original _Start Page+_ feed was of course also restored, but it was broken and there was no UI for us to be able to "fix" it.
However, after a few tweaks to the extension Jan had the feed up and running again.

The only problem is that Jan's extension relies on displaying the _Start Page_ that has been "hidden" in VS 2019.
This page's code, as a [Microsoft employee reminded us][microsoft-employee-url], "_is subject to **vanish at anytime**_".

[jan-kučera-url]: https://developercommunity.visualstudio.com/users/863/047cb52a-d0ac-4677-9337-118da1c525e4.html
[start-page-on-startup-url]: https://marketplace.visualstudio.com/items?itemName=JanKucera.StartPageOnStartup
[microsoft-employee-url]: https://developercommunity.visualstudio.com/comments/513807/view.html

## Start Page+ Is Back!

The [Start Page+][start-page-plus-url] extension adds a new **dockable tool window** to display the same Start Page+ feed
that VS 2017's _Start Page_ used to provide.

However it doesn't actually rely on the RSS feed control that's embedded in VS 2019's hidden _Start Page_ implementation.
So when Microsoft removes the code for the _Start Page_, and I do believe that they'll remove it at some point,
any extensions that rely on that code will cease to function.

Unless of course they decide to give us back the _Start Page_
as so many of us have been asking for in [Start Page: Please give it back!][give-back-start-page-url]

_Start Page+_ has been written **from the ground up** and will therefore **not** be affected.

To open the new _Start Page+_ window:

- select **View** | **Start Page+**

![Dev News](assets/images/dev-news.png)

The old _Start Page+_ feed is just the **first** developer-focused feed to be added to the new _Start Page+_ window,
with **more feeds to come** in the near future (check out [the roadmap][roadmap-url] for more details).

[start-page-plus-url]: https://marketplace.visualstudio.com/items?itemName=YannDuran.StartPagePlus
[roadmap-url]: https://luminous-software.solutions/start-page-plus/roadmap
[give-back-start-page-url]: https://developercommunity.visualstudio.com/idea/434456/start-page-please-give-it-back.html

## Support the Project

If *Extensibility Logs* has saved you time and hassle, please come back and show your support:

- you could [***rate *Extensibility Logs****][rate-or-review-url] (only takes a couple of seconds)
- or [***review *Extensibility Logs****][rate-or-review-url] (help others benefit from your experience)
- or [***shout me a coke***](https://www.paypal.me/yannduran/5) (I don't drink coffee or beer lol)

[rate-or-review-url]: https://marketplace.visualstudio.com/items?itemName=YannDuran.StartPagePlus#review-details
[qna-url]: https://marketplace.visualstudio.com/items?itemName=YannDuran.StartPagePlus#qna
[suggestions-url]: https://marketplace.visualstudio.com/items?itemName=YannDuran.StartPagePlus#qna
