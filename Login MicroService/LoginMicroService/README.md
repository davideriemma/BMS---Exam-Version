Import System.Runtime.InteropServices

' Nei progetti di tipo SDK come questo diversi attributi di assembly che sono stati
' definiti cronologicamente in questo file vengono ora aggiunti automaticamente durante
' la compilazione e popolati con i valori definiti nelle proprietà del progetto. Per
' informazioni dettagliate sugli attributi inclusi e su come personalizzare questo
' processo, vedere: https://aka.ms/assembly-info-properties


' Se si imposta ComVisible su false, i tipi in questo assembly non saranno visibili
' ai componenti COM. Se è necessario accedere a un tipo in questo assembly da COM,
' impostare su true l'attributo ComVisible per tale tipo.

<Assembly: ComVisible(False)> 

' Se il progetto viene esposto a COM, il GUID seguente verrà usato come ID di typelib.

<Assembly: Guid("b8ad020b-b918-4bfc-9013-99c9b0e06b4a")> 

# Struttura della cartella

- SQLiteAdapter -> contains the database-firts model, as well as the context class, which accounts for the **SQLite Adapter**
- LoginAPI -> contains the classes which are responsible of handling a RESTful request. The directory tree mirrors the url of the request
- Application.cs -> the main application, which uses the Minimal API to create a simple web application. All it really does is mapping 
urls with the handlers
