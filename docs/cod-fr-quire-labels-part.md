# CodFrQuireLabelsPart

Codicological fragments quire labels for signatures.

- `CodFrQuireLabelsPart` (`it.vedph.ndp.cod-fr-quire-labels`):
  - labels (`CodFrQuireLabel[]`):
    - `types`\* (`string[]`, 📚 `cod-fr-quire-label-types`: flags like alfabeto latino, greco, cifre arabe, romane, decorato, altro; hidden if no such thesaurus).
    - `text` (`string`)
    - `positions`\* (`string[]`, 📚 `cod-fr-quire-label-positions`: flags like margine inferiore, margine superiore, centro, angolo interno, angolo esterno, colonna A, colonna B).
    - `handId` ([AssertedCompositeId](https://github.com/vedph/cadmus-bricks-shell-v3/blob/master/projects/myrmidon/cadmus-refs-asserted-ids/README.md#asserted-composite-id))
    - `ink` (`string`, free text)
    - `note` (`string`, free text)
