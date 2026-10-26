# Webex Messaging Library – UiPath

## Zweck

Mit dieser Library können Nachrichten über die Webex REST API direkt aus UiPath in einen Webex Space gesendet werden.

## Voraussetzungen

Für die Nutzung werden folgende Variablen benötigt:

| Variable | Typ | Beschreibung |
|---|---|---|
| `in_secure_Webex_Room_Id` | `SecureString` | ID des Webex Spaces |
| `in_str_Webex_Message` | `String` | Inhalt der Nachricht |
| `sec_webextoken` | `SecureString` | Webex Access Token |

Die Room-ID und den Access Token sicher speichern und über den Orchestrator bereitstellen.

## Webex Space ID ermitteln

1. Webex öffnen.
2. Den gewünschten Space auswählen.
3. Die Tastenkombination **Strg + Umschalt + K** drücken.
4. Die angezeigte Space-ID kopieren und als Credential im Orchestrator hinterlegen.

Achte darauf, die ID des richtigen Spaces zu verwenden.

## Nachricht erstellen

Der Nachrichteninhalt wird über die Variable `in_str_Webex_Message` übergeben.

Beispiel für eine Tageszusammenfassung:

```vb
"**Tageszusammenfassung " + str_Date + "**" + Environment.NewLine +
"Gesamt: " + int_CountTotal.ToString + Environment.NewLine +
" | Erfolgreich: " + int_CountSuccessfull.ToString + Environment.NewLine +
" | Fehlgeschlagen: " + int_CountFailed.ToString + Environment.NewLine +
" | Ignorieren: " + int_CountIgnored.ToString + Environment.NewLine +
" | Dublette: " + int_CountDuplicate.ToString + Environment.NewLine +
" | Unbekannte Bemerkungen: " + int_CountUnknownComment.ToString
```

Die Variablen für Datum und Zähler müssen vorher initialisiert werden.

**Hinweis:** Die Nachricht wird über das `text`-Feld der Webex API verschickt. Markdown-Formatierungen wie `**fett**` werden im `text`-Feld nicht garantiert formatiert dargestellt.

## Technische Umsetzung

Die Library erstellt einen HTTP-Request an:

`https://webexapis.com/v1/messages`

- Methode: `POST`
- Content-Type: `application/json`
- Authentifizierung: Bearer Token über `in_secure_webexToken`
- Empfänger: Space-ID über `in_secure_Webex_Room_Id`
- Nachrichteninhalt: `in_str_Webex_Message`
