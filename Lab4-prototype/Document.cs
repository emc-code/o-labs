namespace Lab4_prototype;


public class Document : ICloneable, ICustomCloneable<Document>
{
    public string Text { get; init; }

    public Document(string text) => Text = text;

    public Document(Document source) => Text = source.Text;

    public virtual object Clone() => new Document(Text);

    public virtual Document CustomClone() => (Document)Clone();
}


public class PrivateDocument : Document
{
    public bool IsPrivate { get; init; }

    public PrivateDocument(string text, bool isPrivate) : base(text) => IsPrivate = isPrivate;

    public PrivateDocument(PrivateDocument source) : base(source) => IsPrivate = source.IsPrivate;

    public override object Clone() => new PrivateDocument(this);

    public override PrivateDocument CustomClone() => (PrivateDocument)Clone();
}

public class TempDocument : Document
{
    public TimeOnly LifeTime { get; init; }

    public TempDocument(string text, TimeOnly lifeTime) : base(text) => LifeTime = lifeTime;

    public TempDocument(TempDocument source) : base(source) => LifeTime = source.LifeTime;

    public override object Clone() => new TempDocument(this);

    public override TempDocument CustomClone() => (TempDocument)Clone();
}