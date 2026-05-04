# Seznam aktivních letů

## GET /flight/inAir

- Vrací seznam všech aktuálně aktivních letů.

- Registrace přistání

## POST /flight/land

- Zaregistruje přistání letadla. Tělo požadavku obsahuje identifikaci letu a čas přistání.

- Seznam klubových letadel

## GET /airplane

- Vrací seznam všech klubových letadel včetně typu a imatrikulace.

- Seznam členů klubu

## GET /user

- Vrací seznam členů klubu používaný při výběru pilotů a kopilotů.

- Registrace vzletu

## POST /flight/takeoff

- Zaregistruje vzlet vlečného letadla a případně i kluzáku. Tělo požadavku obsahuje kompletní údaje z formuláře „Nový let“.

- Report všech letů

## GET /flight/report

- Vrací seznam všech zaregistrovaných letů včetně údajů o osádce, časech a délce letu.

- Export letů do CSV

## GET /flight/export

- Endpoint je určen pro export letů ve formátu CSV.