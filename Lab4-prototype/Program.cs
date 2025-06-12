using Lab4_prototype;
using System.Drawing;


/*
 * ICloneable 
 * + стандартный\ожидаемый интерфейс
 * - нужен кастинг
 * IMyCloneable
 * + типобезопасен
 * - нужна собственная реализация
 */

Row row = new Row(1, 5);
Row clonedRow = row.CustomClone();
Console.WriteLine($"[Row] RowNumber={clonedRow.RowNumber}, ColumnCount={clonedRow.ColumnCount}");

RowHeader header = new RowHeader(2, 4, Color.Red);
RowHeader clonedHeader = header.CustomClone();
Console.WriteLine($"[RowHeader] RowNumber={clonedHeader.RowNumber}, ColumnCount={clonedHeader.ColumnCount}, Color={clonedHeader.Color}");

RowFooter footer = new RowFooter(3, 6, true);
RowFooter clonedFooter = footer.CustomClone();
Console.WriteLine($"[RowFooter] RowNumber={clonedFooter.RowNumber}, ColumnCount={clonedFooter.ColumnCount}, MustUnderscoring={clonedFooter.MustUnderscoring}");

var user = new User("Иванов И.И.");
var clonedUser = user.CustomClone();
Console.WriteLine($"[User] FIO: {user.FIO} | Clone FIO: {clonedUser.FIO}");

var admin = new Admin("Петров П.П.", true);
var clonedAdmin = admin.CustomClone();
Console.WriteLine($"[Admin] FIO: {admin.FIO}, IsCreater: {admin.IsCreater} | Clone IsCreater: {clonedAdmin.IsCreater}");

var removed = new RemovedUser("Сидоров С.С.", true);
var clonedRemoved = removed.CustomClone();
Console.WriteLine($"[RemovedUser] FIO: {removed.FIO}, IsDeleted: {removed.IsDeleted} | Clone IsDeleted: {clonedRemoved.IsDeleted}");

var doc = new Document("Документ 1");
var clonedDoc = doc.CustomClone();
Console.WriteLine($"[Document] Text: {doc.Text} | Clone Text: {clonedDoc.Text}");

var privDoc = new PrivateDocument("Секретный документ", true);
var clonedPriv = privDoc.CustomClone();
Console.WriteLine($"[PrivateDocument] Text: {privDoc.Text}, IsPrivate: {privDoc.IsPrivate} | Clone IsPrivate: {clonedPriv.IsPrivate}");

var tempDoc = new TempDocument("Временный документ", new TimeOnly(12, 30));
var clonedTemp = tempDoc.CustomClone();
Console.WriteLine($"[TempDocument] Text: {tempDoc.Text}, LifeTime: {tempDoc.LifeTime} | Clone LifeTime: {clonedTemp.LifeTime}");
