# Probearbeit-Postnova-

## 1, Bereich Mathematik:
Bitte zuvor genau durchlesen: https://en.wikipedia.org/wiki/Significant_figures  
Beachten sie dabei insbesondere die Bereiche „misleading level of precision“ und wie es an den Messwerten angewendet werden kann.   
Überlegen Sie dabei, wie Sie vorgehen sollen um eine sinnvolle Rundung der Messwerte zu bestimmen.   

Bitte schreiben Sie einen Source Code (WPF oder Konsole):  
A,	der die angefügte Datei: data.txt (x,y Werte) einlesen kann.  
B,	Aus den y – Werten die Standardabweichung und den Mittelwert berechnen kann.  
C,	Aus den x und y Werten die erste 1. und 2. Derivative berechnen kann.

    Lösung im Projekt (Verzeichnis) MathApp
*****
##  2, Bereich WPF Kenntnisse: 
A, 	Welche WPF Design Pattern kennen Sie? Bitte beschreiben Sie alle Ihnen bekannten Patten in zwei bis drei Sätzen.
    
    MVVM (Model-View-ViewModel): Trennt die UI-Logik von der Geschäftslogik durch Datenbindung und Befehle. ViewModel fungiert als Vermittler zwischen View und Model, unterstützt bidirektionale Datenbindung und Unit-Tests und ist das kern und am häufigsten verwendete Patten in WPF.

    Dependency Injection/Inversion of Control: Wird oft mit MVVM kombiniert, verwaltet ViewModel- und Serviceabhängigkeiten über einen IoC-Container, wodurch Testbarkeit und Modularität verbessert werden.

    Command Pattern: Durch die Implementierung der ICommand-Schnittstelle werden Benutzeroperationen (wie z. B. Schaltflächenklicks) in Befehlsobjekte gekapselt, wodurch UI-Ereignisse von der Geschäftslogik getrennt werden. Es wird häufig mit MVVM verwendet.

    Observer Pattern: Implementieren Sie Benachrichtigungen über Datenänderungen über die Schnittstellen INotifyPropertyChanged und INotifyCollectionChanged, sodass die Benutzeroberfläche automatisch auf Datenaktualisierungen reagieren kann.
    
B, 	Bitte erstellen Sie eine WPF Anwendung, die ein WPF Pattern nutzt und ein beliebiges Verzeichnis (bitte mit mehr als 10 Dateien) auf Ihren PC ausliest und deren Datei-Properties anzeigt. Ebenso soll die HashSum der Dateien ausgeben werden.

    Lösung im Projekt (Verzeichnis) FilePropertyViewer

