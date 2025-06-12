namespace Lab4_prototype;

internal class User : ICloneable, ICustomCloneable<User>
{
    public string FIO { get; init; }

    public User(string fio) => FIO = fio;

    public User(User source) => FIO = source.FIO;

    public virtual object Clone() => new User(this);

    public virtual User CustomClone() => (User)Clone();
}

internal class Admin : User, ICloneable, ICustomCloneable<Admin>
{
    public bool IsCreater { get; init; }

    public Admin(string fio, bool isCreater) : base(fio) => IsCreater = isCreater;

    public Admin(Admin source) : base(source) => IsCreater = source.IsCreater;

    public object Clone() => new Admin(this);

    public override Admin CustomClone() => (Admin)Clone();
}

internal class RemovedUser : User, ICloneable, ICustomCloneable<RemovedUser>
{
    public bool IsDeleted { get; init; }

    public RemovedUser(string fio, bool isDeleted) : base(fio) => IsDeleted = IsDeleted;

    public RemovedUser(RemovedUser source) : base(source) { IsDeleted = source.IsDeleted; }

    public override object Clone() => new RemovedUser(this);

    public override RemovedUser CustomClone() => (RemovedUser)Clone();
}