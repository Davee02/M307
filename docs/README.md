# M307 Projektarbeit (By David Hodel & Simon Müri)

## Konzeptionierung

### Formulare

#### Neue Reparatur erfassen

##### Mockup

![Create-Formular](./img/create_formular.png)

##### Datentypen

| Feld                  | Datentyp                       |
|-----------------------|--------------------------------|
| Vorname               | string                         |
| Nachname              | string                         |
| Email-Adresse         | string                         |
| Telefon               | string                         |
| Dringlichkeit         | Einfach-Auswahl durch Combobox |
| Betreffendes Werkzeug | Einfach-Auswahl durch Combobox |

#### Bestehende Reparatur bearbeiten

##### Mockup

![Edit-Formular](./img/edit_formular.png)

##### Datentypen

| Feld                 | Datentyp                       |
|----------------------|--------------------------------|
| Vorname              | string                         |
| Nachname             | string                         |
| E-Mail               | string                         |
| Telefon              | string                         |
| Status der Reparatur | Einfach-Auswahl durch Combobox |
| Werkzeug             | Einfach-Auswahl durch Combobox |

### Validierung

| Formularfeld         | Validierungen                                  |
|----------------------|------------------------------------------------|
| Vorname              | Required                                       |
| Nachname             | Required                                       |
| Telefon              | Nur Ziffern, Leerzeichen, `+`, `-`, `(`und `)` |
| E-Mail               | Muss ein `@` enthalten, Required               |
| Dringlichkeit        | Required                                       |
| Werkzeug             | Required                                       |
| Status der Reparatur | Required                                       |

### Datenbank

**Tabelle `RepairOrders`**

| Feld-Bezeichnungen  | Datentyp      |
|---------------------|---------------|
| Id                  | int           |
| Firstname           | nvarchar(200) |
| Lastname            | nvarchar(200) |
| Phone               | nvarchar(200) |
| Email               | nvarchar(200) |
| Severety            | int           |
| Tool                | int           |
| RepairState         | int           |
| RepairStartDateTime | dateTime2     |

**Tabelle `Tools`**

| Feld-Bezeichnungen | Datentyp      |
|--------------------|---------------|
| Id                 | int           |
| ToolName           | nvarchar(200) |

### Testfälle

| Nummer | Gegeben sei                     | Wenn                                                  | Dann                                                                           |
|--------|---------------------------------|-------------------------------------------------------|--------------------------------------------------------------------------------|
| 1      | Ich bin auf der Startseite      | ich auf "edit" klicke                                 | öffnet das Edit-Formular                                                       |
| 2      | Ich bin auf der Startseite      | ich auf "create new" klicke                           | öffnet sich das Create-Formular                                                |
| 4      | Ich bin auf dem Create-Formular | ich den Vornamen eingebe und auf "create" klicke      | wird das Feld korrekt validiert                                                |
| 4      | Ich bin auf dem Create-Formular | ich den Nachnamen eingebe und auf "create" klicke     | wird das Feld korrekt validiert                                                |
| 5      | Ich bin auf dem Create-Formular | ich die Telefonnummer eingebe und auf "create" klicke | wird das Feld korrekt validiert (Nur Ziffern, Leerzeichen, `+`, `-`, `(`, `)`) |
| 6      | Ich bin auf dem Create-Formular | ich die Email eingebe und auf "create" klicke         | wird das Feld korrekt validiert (enthält ein `@`)                              |
| 7      | Ich bin auf dem Create-Formular | ich auf dem Formular bin                              | steht bei der Dringlichkeit `Please select`                                    |
| 8      | Ich bin auf der Edit-Formular   | ich auf "edit" klicke                                 | sollen alle Felder gemäss oben definiert validiert werden                      |
| 9      | Ich bin auf der Create-Formular | ich auf "Severety" ändere                             | wird das Enddatum angepasst                                                    |
| 10     | Ich bin auf der Edit-Formular   | ich auf dem Formular bin                              | sollen die bestimmten Felder (Severety, Repair end-date) nicht editierbar sein |

## Testbericht

| Nummer | Testresultat                        |
|--------|-------------------------------------|
| 1      | Test wurde erfolgreich durchgeführt |
| 2      | Test wurde erfolgreich durchgeführt |
| 4      | Test wurde erfolgreich durchgeführt |
| 4      | Test wurde erfolgreich durchgeführt |
| 5      | Test wurde erfolgreich durchgeführt |
| 6      | Test wurde erfolgreich durchgeführt |
| 7      | Test wurde erfolgreich durchgeführt |
| 8      | Test wurde erfolgreich durchgeführt |
| 9      | Test wurde erfolgreich durchgeführt |
| 10     | Test wurde erfolgreich durchgeführt |