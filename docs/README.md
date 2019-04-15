# M307 Projektarbeit (By David Hodel & Simon Müri)

## Konzeptionierung

### Formulare

#### Neue Reparatur erfassen

##### Mockup

![Create-Formular](./img/create_formular.png)

##### Datentypen

| Feld                  | Datentyp                          |
|-----------------------|-----------------------------------|
| Vorname               | string                            |
| Nachname              | string                            |
| Email-Adresse         | string                            |
| Telefon               | string                            |
| Dringlichkeit         | Einfach-Auswahl durch Radiobutton |
| Betreffendes Werkzeug | Einfach-Auswahl durch Combobox    |

#### Bestehende Reparatur bearbeiten

##### Mockup

![Edit-Formular](./img/edit_formular.png)

##### Datentypen

| Feld                 | Datentyp                          |
|----------------------|-----------------------------------|
| Vorname              | string                            |
| Nachname             | string                            |
| Email-Adresse        | string                            |
| Telefon              | string                            |
| Status der Reparatur | Einfach-Auswahl durch Radiobutton |
| Werkzeug             | Einfach-Auswahl durch Combobox    |

### Validierung

| Formularfeld        | Validierungen                                  |
|---------------------|------------------------------------------------|
| Vorname             | Required                                       |
| Nachname            | Required                                       |
| Telefon             | Nur Ziffern, Leerzeichen, `+`, `-`, `(`und `)` |
| E-Mail              | Muss ein `@`  enthalten                        |
| Dringlichkeit       | Required                                       |
| Werkzeug            | Required                                       |
| Status der Repratur | Required                                       |

### Datenbank

**Tabelle `RepairOrders`**

| Feld-Bezeichnungen | Datentyp      |
|--------------------|---------------|
| Id                 | int           |
| Firstname          | nvarchar(200) |
| Lastname           | nvarchar(200) |
| Phone              | nvarchar(200) |
| Email              | nvarchar(200) |
| Severety           | int           |
| Tool               | int           |
| RepairState        | int           |

**Tabelle `Tools`**

| Feld-Bezeichnungen | Datentyp      |
|--------------------|---------------|
| Id                 | int           |
| ToolName           | nvarchar(200) |

### Testfälle

## Testbericht