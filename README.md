\# Equipment Rental System



Aplikacja konsolowa w C# do obsługi uczelnianej wypożyczalni sprzętu.

Projekt został wykonany w ramach przedmiotu APBD.



Repozytorium



https://github.com/Roznowicz/apbd-cw2-git-s33876



\---



Struktura projektu



Projekt został podzielony na trzy główne warstwy:



\* \*\*Domain\*\* – model domenowy (sprzęt, użytkownicy, wypożyczenia)

\* \*\*Services\*\* – logika biznesowa (operacje na systemie)

\* \*\*Program.cs\*\* – scenariusz demonstracyjny (interfejs konsolowy)



\---



Decyzje projektowe



\* Zastosowano \*\*dziedziczenie\*\* dla klas `User` oraz `Equipment`

\* Logika biznesowa została wydzielona do klas serwisowych (`RentalService`, `EquipmentService`, itd.)

\* Klasa `PenaltyCalculator` odpowiada za naliczanie kar za opóźnienia

\* `Program.cs` pełni wyłącznie rolę prezentacji działania systemu



\---



Kohezja i Coupling



\* Każda klasa ma \*\*jedną odpowiedzialność\*\* (zasada SRP)

\* Logika biznesowa nie jest rozproszona – znajduje się w serwisach

\* Interfejs użytkownika (Program.cs) nie zawiera logiki biznesowej

\* Zależności między klasami są ograniczone do minimum



\---



Funkcjonalności



\* Dodawanie użytkowników

\* Dodawanie sprzętu różnych typów (Laptop, Projector, Camera)

\* Wypożyczanie sprzętu

\* Zwrot sprzętu

\* Obsługa limitów wypożyczeń:



&#x20; \* Student – max 2

&#x20; \* Employee – max 5

\* Naliczanie kar za opóźnienie

\* Generowanie raportów

\* Wyświetlanie dostępnego sprzętu



\---



Reguły biznesowe



\* Nie można wypożyczyć sprzętu niedostępnego

\* Użytkownik nie może przekroczyć limitu wypożyczeń

\* Opóźniony zwrot skutkuje naliczeniem kary

\* Reguły zostały wydzielone w sposób umożliwiający łatwą modyfikację



\---



Uruchomienie



dotnet run



\---



\##  Scenariusz demonstracyjny



Program prezentuje:



\* Dodanie sprzętu i użytkowników

\* Poprawne wypożyczenie sprzętu

\* Próbę wykonania błędnej operacji

\* Przekroczenie limitu użytkownika

\* Zwrot sprzętu w terminie

\* Zwrot po terminie z naliczeniem kary

\* Generowanie raportu końcowego



\---



Podsumowanie



Projekt spełnia wymagania zadania oraz demonstruje zastosowanie podstawowych zasad programowania obiektowego, takich jak:



\* separacja odpowiedzialności

\* modularność

\* czytelność kodu

\* możliwość łatwej rozbudowy systemu



