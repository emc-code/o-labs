using System.Drawing;

namespace Lab4_prototype;

public class Row : ICloneable, ICustomCloneable<Row>
{
    public int RowNumber { get; init; }
    public int ColumnCount { get; init; }

    public Row(int rowNumber, int columtCount) =>
        (RowNumber, ColumnCount) = (rowNumber, columtCount);

    public Row(Row source)
    {
        this.RowNumber = source.RowNumber;
        this.ColumnCount = source.ColumnCount;
    }

    public virtual object Clone() => new Row(this);

    public virtual Row CustomClone() => (Row)Clone();
}


public class RowHeader : Row
{
    public Color Color { get; init; }

    public RowHeader(int rowNumber, int columnCount, Color color)
        : base(rowNumber, columnCount) => Color = color;

    protected RowHeader(RowHeader source)
       : base(source) => Color = source.Color;

    public override object Clone() => new RowHeader(this);

    public override RowHeader CustomClone() => (RowHeader)Clone();
}

public class RowFooter : Row
{
    public bool MustUnderscoring { get; init; }

    public RowFooter(int rowNumber, int columnCount, bool mustUnderscoring) : base(rowNumber, columnCount) =>
        MustUnderscoring = mustUnderscoring;

    protected RowFooter(RowFooter source) : base(source) => MustUnderscoring = source.MustUnderscoring;

    public override object Clone() => new RowFooter(this);

    public override RowFooter CustomClone() => (RowFooter)Clone();
}