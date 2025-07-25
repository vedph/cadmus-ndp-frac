﻿# Cadmus NDP FRAC

- [Cadmus models reference](https://myrmex.github.io/overview/cadmus/dev/models/)
- [Cadmus bricks playground](https://cadmus-bricks.fusi-soft.com/)
- [Cadmus NDP Books](https://github.com/vedph/cadmus-ndp-books)
- [Cadmus NDP Drawings](https://github.com/vedph/cadmus-ndp-drawings)

- [Cadmus NDP FRAC](#cadmus-ndp-frac)
  - [New Parts](#new-parts)
    - [CodFrLayoutPart](#codfrlayoutpart)
    - [CodFrQuireLabelsPart](#codfrquirelabelspart)
    - [CodFrRulingsPart](#codfrrulingspart)
    - [CodFrSupportPart](#codfrsupportpart)
  - [Item - Fragment](#item---fragment)
  - [History](#history)
    - [0.0.3](#003)
    - [0.0.2](#002)

In what follows:

- 🟢 marks a [general](https://vedph.github.io/cadmus-doc/models/shared.html#general) or bibliographic part.
- 📖 marks a [codicology](https://vedph.github.io/cadmus-doc/models/shared.html#codicology) part.
- ⭐ marks a new part. The star is used once, even when that part is then reused in other items. If a part marked with a star has a link to documentation, this means that I have already implemented it as I could do this in advance for generic parts. All the other parts are still to be implemented.
- ⚠️ marks an area where the model must still be defined with a discussion.

```mermaid
graph LR;
FRAGMENT --> identity
identity --> metadata
identity --> cod_shelfmarks
identity --> pin-links
FRAGMENT --> history
history --> chronotopes
history --> events
history --> note:hist
FRAGMENT --> material
material --> cod_fr-support
material --> decorated-counts
material --> measurements
material --> states
FRAGMENT --> content
content --> cod_contents
content --> cod_hands
content --> cod_edits
content --> cod_fr-layout
content --> cod_fr-rulings
content --> cod_fr-quire-labels
content --> cod_fr-quire-labels:sig
content --> cod_fr-quire-labels:catch
content --> cod_decorations
FRAGMENT --> references
references --> ext-bibliography
```

## New Parts

### CodFrLayoutPart

The layout the codicological fragment was part of.

- ⭐ `CodFrLayoutPart`:
  - `formula`\* (`string`): the layout formula. Usually this follows [Bianconi-Orsini](https://github.com/vedph/cod-layout-view?tab=readme-ov-file#bianconi-orsini).
  - `dimensions` (`PhysicalDimension[]`): dimensions of any measurable elements in the layout, including those automatically derived from the layout formula.
  - `pricking`\* (`string`, 📚 `cod-fr-layout-prickings`): the pricking type (including no pricking), usually from thesaurus.
  - `columnCount`\* (`int`): the columns count, when it can be determined. Otherwise it is 0.
  - `counts` (`DecoratedCount[]`): any type of countable elements in the layout with their value.
  - `note` (`string`): free text note.

### CodFrQuireLabelsPart

Codicological fragments quire labels for signatures.

- ⭐ `CodFrQuireLabelsPart`:
  - labels (`CodFrQuireLabel[]`):
    - `types`\* (`string[]`, 📚 `cod-fr-quire-label-types`: flags like alfabeto latino, greco, cifre arabe, romane, decorato, altro; hidden if no such thesaurus).
    - `text` (`string`)
    - `positions`\* (`string[]`, 📚 `cod-fr-quire-label-positions`: flags like margine inferiore, margine superiore, centro, angolo interno, angolo esterno, colonna A, colonna B).
    - `handId` ([AssertedCompositeId](https://github.com/vedph/cadmus-bricks-shell-v3/blob/master/projects/myrmidon/cadmus-refs-asserted-ids/README.md#asserted-composite-id))
    - `ink` (`string`, free text)
    - `note` (`string`, free text)

### CodFrRulingsPart

Codicological fragment rulings.

- ⭐ `CodFrRulingsPart`:
  - `rulings` (`CodFrRuling[]`):
    - `system` (`string`, 📚 `cod-fr-ruling-systems`)
    - `type` (`string`, 📚 `cod-fr-ruling-types`)
    - `features`\* (`string[]` 📚 `cod-fr-ruling-features`, flags like a secco, a mina, a inchiostro, a colore, piegatura, altro, non individuabile).
    - `note` (`string`)

### CodFrSupportPart

Codicological fragment support.

- ⭐ `CodFrSupportPart`:
  - `container`\* (`string`, 📚 `cod-fr-support-containers`, e.g. busta, codice ospite, codice fattizio, altro).
  - `material`\* (`string`, 📚 `cod-fr-support-materials`)
  - `location`\* (`string`): a location relative to an ideal rectangular grid overlaid on top of the surface of the object the fragment belonged to. The location is expressed as a set of coordinates, see <https://cadmus-bricks.fusi-soft.com/mat/physical-grid> for a demo.
  - `hasPricking` (`boolean`)
  - `layout`\* formula (`string`, ⚠️ codicology-like to be defined according to D. Bianconi, _I Codices Graeci Antiquiores tra scavo e biblioteca_, in _Greek Manuscript Cataloguing: Past, Present, and Future_, edited by P. Degni, P. Eleuteri, M. Maniaci, Turnhout, Brepols, 2018 (Bibliologia, 48), 99-135, especially 110-111).
  - `reuse` type (`string`, 📚 `cod-fr-support-reuse-types`)
  - `supposedReuse` type (`string`, 📚 `cod-fr-support-reuse-types`)

## Item - Fragment

This item represents a single fragment.

- identity:
  - 🟢 [metadata part](https://github.com/vedph/cadmus-general/blob/master/docs/metadata.md)
  - 📖 [COD codicology shelfmarks part](https://github.com/vedph/cadmus-codicology/blob/master/docs/cod-shelfmarks.md)\*: either an existing shelfmark ID for the fragment, or a one created for it if the fragment has none (e.g.` Vat. lat. 13501 Fr.A` for a fragment in a manuscript with shelfmark `Vat. lat. 13501`).
  - 🟢 [pin links part](https://github.com/vedph/cadmus-general/blob/master/docs/pin-links.md): this links the fragment to its original container and current container. The different role of the link (original vs current) is defined by the link's tag. Each link can also include an assertion.

- history:
  - 🟢 [chronotopes part](https://github.com/vedph/cadmus-general/blob/master/docs/chronotopes.md)
  - 🟢 [historical events part](https://github.com/vedph/cadmus-general/blob/master/docs/historical-events.md)
  - 🟢 [note part](https://github.com/vedph/cadmus-general/blob/master/docs/note.md):`hist`
  - 🟢 [external bibliography part](https://github.com/vedph/cadmus-general/blob/master/docs/ext-bibliography.md)

- support:
  - ⭐ [CodFrSupportPart](#codfrsupportpart)\*
  - 🟢 [decorated counts part](https://github.com/vedph/cadmus-general/blob/master/docs/decorated-counts.md)
  - 🟢 [physical measurements part](https://github.com/vedph/cadmus-general/blob/master/docs/physical-measurements.md)
  - 🟢 [physical states part](https://github.com/vedph/cadmus-general/blob/master/docs/physical-states.md)

- content:
  - ⭐ [CodFrLayoutPart](#codfrlayoutpart)
  - 📖 [COD codicology contents part](https://github.com/vedph/cadmus-codicology/blob/master/docs/cod-contents.md)\*. A fragment typically includes a few verses, with optional lacunae in it. To represent this we can still use the codicology contents part, adding a content for each content covered by the fragment. So for instance if a fragment contains If.1,20-23 and If.1,25 (i.e. If 1.20-25 where 24 is missing) we just add 2 content entries for these two contents (optionally we can also use the tag to group these two contents together). Like any content entry each has its incipit, explicit etc. ⚠️ Determine if other properties are required.
  - 📖 [COD codicology hands part](https://github.com/vedph/cadmus-codicology/blob/master/docs/cod-hands.md)\*
  - 📖 [COD codicology edits part](https://github.com/vedph/cadmus-codicology/blob/master/docs/cod-edits.md)
  - ⭐ [CodFrRulingsPart](#codfrrulingspart)\*
  - [links part](https://github.com/vedph/cadmus-general/blob/master/docs/fr.pin-links.md): links to the original/current container (a ms item). An _item flag_ will mark a reconstructed manuscript.
  - ⭐ [CodFrQuireLabelsPart](#codfrquirelabelspart):`sig`: quire labels for signatures.
  - ⭐ [CodFrQuireLabelsPart](#codfrquirelabelspart):`catch`: quire labels for catchwords.
  - 📖 [COD CodDecorationsPart](https://github.com/vedph/cadmus-codicology/blob/master/docs/cod-decorations.md)

>The codicological formula targets size and text area (D. Bianconi, P. Orsini). See the [CodLayoutView](https://github.com/vedph/cod-layout-view) library for it.

Fragments are usually contained in manuscripts, so fragments references will target them in the codicological section of the database.

## History

### 0.0.9

- 2025-07-16: updated packages.
- 2025-07-14: updated packages.
- 2025-07-08: fixed seeder tag.

### 0.0.6

- 2025-07-03: added `CodFrLayoutPart` extracting its data from `CodFrSupportPart`.
- 2025-06-29: renamed support `preservationPlace` to `container` to properly reflect its meaning.
- 2025-06-22: more data and thesauri in seeders.

### 0.0.3

- 2025-06-21: use `AssertedCompositeId` for `handId` in `CodFrQuireLabelsPart`.

### 0.0.2

- 2025-06-16: minor refinements in models.
