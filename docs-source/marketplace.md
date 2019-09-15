![Version][version-badge-url]
[![License][license-badge]](https://github.com/luminous-software/start-page-plus/blob/master/LICENSE)
[![Donate][paypal-badge]](https://www.paypal.me/yannduran/5)

[version-badge-url]: http://vsmarketplacebadge.apphb.com/version-short/YannDuran.StartPagePlus.svg?label=version&colorB=7E57C2&style=flat-square
[license-badge]: https://img.shields.io/badge/license-MIT-7E57C2.svg?style=flat-square
[license-url]: https://github.com/luminous-software/start-page-plus/blob/master/LICENSE
[paypal-badge]: https://img.shields.io/badge/donate-paypal-green.svg?style=flat-square
[paypal-url]: https://www.paypal.me/yannduran/10

You can download this extension [from the Visual Studio Marketplace][marketplace-url]

[marketplace-url]: https://marketplace.visualstudio.com/items?itemName=YannDuran.StartPagePlus

---

Please understand that this is a **preview release**.

While the features of the **_Start Tab_** are functional in this preview (I'm using it myself),
there are still some quirks that need to be ironed out, plus a number of missing features that still
need to be added.
I just wanted to get this up to the marketplace as quickly as I could, so people can see it and
start to use it.

**Feedback is welcome!** But please use the GitHub repo's [Issues page][github-issues-page] to
provide it, **don't** add your ideas and/or feeback to any blog post where you might have
discovered _Start Page+_.
I won't be able to address your feedback in those posts, as it's not fair to the OP to have their
post highjacked.

If you want to know more about _Start Page+_ the [website][start-page-plus-website] is where I'll
add information about _known issues_, and a _roadmap_ of what's coming.
Please **consult the website** first before adding issues for **new features**,
**feature enhancements** etc.
If you don't see your desired feature or enhancement mentioned on the website,
then by all means go ahead and add an issue for it.
The same thing goes for any **bugs** you might run across.

The _Favorites Tab_, _Create Tab_, and _News Tab_ are **still being worked on**.

The **_Favorites Tab_** will allow you to add _columns_ and _groups_ to add your favorite
**solutions**, **projects**, **folders** etc, in a much more **flexible way** than just
_pinned tabs_.
Hopefully, after a while, you won't even need to use pinned tabs anymore.

The **_Create Tab_** aims to provide a **tree view-based** replacement for VS 2019's hated new
**search-based** _Create a New Project_ dialog, baked right into your start page.

The **_News Tab_** will have some pre-populated RSS feeds of developer-centric blogs etc.
Plus, in the future you'll be able to add your own RSS feeds to the tab as well.
Sort of like a mini RSS application embedded in your start page.

[github-issues-page]: https://github.com/luminous-software/start-page-plus/issues
[start-page-plus-website]: https://luminous-software.solutions/start-page-plus

---

## Bring Back Start Page!

When Visual Studio 2019 was released, many developers were dismayed to find that the _Start Page_ had been completely
replaced by the new _Start Window_ (a big **modal** dialog window, with no room for _Developer News_).

![Start Window](https://github.com/luminous-software/start-page-plus/raw/master/docs/assets/images/start-window-dark.png)

## Introducing Start Page+

So many of you, in **so many posts** in the [Developer Community forum][developer-community-forum-url], **pleaded** for Microsoft to bring back the Visual Studio 2017
_Start Page_, and unfortunately those pleas fell on deaf ears.

[developer-community-forum-url]: https://developercommunity.visualstudio.com/search.html?f=&type=question+OR+problem+OR+idea&type=question+OR+problem+OR+idea&c=&redirect=search%2Fsearch&sort=relevance&q=start+page

Well, you asked and now _Start Page+_ delivers!

The [Start Page+][start-page-plus-url] extension adds a new *Start Page* that is a **dockable tool window**,
not a **modal** window.
It's been written **from the ground up**, and doesn't rely on any of Visual Studio's *internal* code.
So it can't be taken  away by Microsoft. And it's open source!

To open the new _Start Page+_ window:

- make sure Visual Studio's *Start Window* is disabled
  - in **Tools** | **Options** | **Environment** | **Startup** select _Empty Environment_

    ![Startup Options](https://github.com/luminous-software/start-page-plus/raw/master/docs/assets/images/startup-options.png)

- select **View** | **Start Page+**

  ![Start Page+](https://github.com/luminous-software/start-page-plus/raw/master/docs/assets/images/start-page-plus.png)

The _Start Page+_ window is accessed from the **View** menu, because it makes sense.
It's also easy to remember because you think "I want to **view** the start page",
you don't think "I want to **file** the start page.

The Visual Studio 2010-2017's _Start Page_ was always in the **View** menu,
until Microsoft moved it to the **File** menu, which never made any sense.

[start-page-plus-url]: https://marketplace.visualstudio.com/items?itemName=YannDuran.StartPagePlus
[roadmap-url]: https://luminous-software.solutions/start-page-plus/roadmap
[give-back-start-page-url]: https://developercommunity.visualstudio.com/idea/434456/start-page-please-give-it-back.html

## More Information

You can read more about _Start Page+_ on its website:

[Overview][website-url] **|** [Getting Started][getting-started-url] **|** [Features][features-url] **|** [Changelog][changelog-url] **|** [Roadmap][roadmap-url]

[website-url]: https://luminous-software.solutions/start-page-plus
[getting-started-url]: https://luminous-software.solutions/start-page-plus/getting-started
[features-url]: https://luminous-software.solutions/start-page-plus/features
[changelog-url]: https://luminous-software.solutions/start-page-plus/changelog
[roadmap-url]: https://luminous-software.solutions/start-page-plus/roadmap

## Support the Project

If *Start Page+* has saved you time and hassle, please come back and show your support:

  - you could [***rate *Start Page+****][rate-or-review-url] (only takes a couple of seconds)
  - or [***review *Start Page+****][rate-or-review-url] (help others benefit from your experience)
  - or [***shout me a coke***](https://www.paypal.me/yannduran/5) (I don't drink coffee or beer lol)

[rate-or-review-url]: https://marketplace.visualstudio.com/items?itemName=YannDuran.StartPagePlus#review-details