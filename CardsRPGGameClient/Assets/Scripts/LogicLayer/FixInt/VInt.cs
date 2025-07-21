using System;
//long a = 1000000;
//long b = 10000;
//a = a + b;


//long value = (long)(b * 1000 * 1.0f / a);

//Console.WriteLine($"{b * 1000 * 1.0f}/{a} �˷�����  =" + value);
////Example6();
//long value2 = (long)((b << 10) * 1.0f / a);
//Console.WriteLine($"10000000/1010000  ��λ���� =" + value2);
//Console.ReadKey();
//ΪʲĪ����x1024 ������ x1000  ��Ϊ������ 2�Ĵ������������ģ�һ���ֽ���1024 byte ��ô 1 ������־�����1024���ֽ���ɵģ�
//��Ϊ������Ҫ��������һ������������������������⣬ ���������������ʱ��1000��1024 ���в��ģ� ���ʱ�����ǿ��԰�һ��int��ֵ����Ϊһ��byte�ֽ�
// ��1024��byte�Ŵ���һ��ֵ�������ǰ�һ���ֽ�����1000������Ȼ�ǲ�׼�ģ����ֲ�׼����ֵ���������ʱ��ͻ����ֳ������������ֵ��
//����˵ 1024 ����׼ȷ��һ������������ʹ�����ֵ��������֮���ܹ���֤�����ڼ����в������ƫ�
//������ʦ��һ������1024 ������1000�����ӣ��ô�ҿ�һ��ΪʲĪ����ƫ�
[Serializable]
public struct VInt:IComparable<VInt>
{
    private long i;
    //λ�Ƽ���
    const int FIX_MULTIPLE = 1024;

    public static readonly VInt one = new VInt((long)FIX_MULTIPLE);
    public int Int { get { return (int)i; } }
    public float RawFloat { get { return (float)this.i * 1.0f / FIX_MULTIPLE; } }
    public int RawInt { get { return (int)i / FIX_MULTIPLE; } }

    private VInt(long i)
    {
        this.i = i;
    }
    public VInt(int i)
    {
        this.i = i * FIX_MULTIPLE;
    }
    public VInt(float f)
    {
        this.i = (int)Math.Round((double)(f * 1.0f * FIX_MULTIPLE));
    }

    public override bool Equals(object o)
    {
        if (o == null)
        {
            return false;
        }
        VInt vInt = (VInt)o;
        return this.i == vInt.i;
    }

    public override int GetHashCode()
    {
        return this.i.GetHashCode();
    }

    public static VInt Min(VInt a, VInt b)
    {
        return new VInt(Math.Min(a.i, b.i));
    }

    public static VInt Max(VInt a, VInt b)
    {
        return new VInt(Math.Max(a.i, b.i));
    }

    public override string ToString()
    {
        return this.RawFloat.ToString();
    }

 

    public int CompareTo(VInt other)
    {
        return i.CompareTo(other.i);
    }

    public static explicit operator VInt(float f)
    {
        return new VInt((int)Math.Round((double)(f * 1.0f * FIX_MULTIPLE)));
    }

    public static implicit operator VInt(int i)
    {

        return new VInt(i);
    }

    public static explicit operator float(VInt ob)
    {
        return (float)ob.i * 1.0f / FIX_MULTIPLE;
    }

    public static explicit operator long(VInt ob)
    {
        return (long)ob.i;
    }

    public static VInt operator +(VInt a, VInt b)
    {
        return new VInt(a.i + b.i);
    }

    public static VInt operator -(VInt a, VInt b)
    {
        return new VInt(a.i - b.i);
    }

    public static VInt operator *(VInt a, VInt b)
    {
        long value = a.i * b.i;
        if (value >= 0)
        {
            value /= FIX_MULTIPLE;
        }
        else
        {
            value = -(-value / FIX_MULTIPLE);
        }
        return new VInt(value);
    }

    public static VInt operator /(VInt a, VInt b)
    {
        return new VInt((a.i * FIX_MULTIPLE / b.i));
    }
    public static bool operator ==(VInt a, VInt b)
    {
        return a.i == b.i;
    }
    public static VInt operator -(VInt a)
    {
        return new VInt(-a.i);
    }

    public static bool operator !=(VInt a, VInt b)
    {
        return a.i != b.i;
    }

    public static bool operator >(VInt a, VInt b)
    {
        return a.i > b.i;
    }
    public static bool operator <(VInt a, VInt b)
    {
        return a.i < b.i;
    }
    public static bool operator >=(VInt a, VInt b)
    {
        return a.i >= b.i;
    }
    public static bool operator <=(VInt a, VInt b)
    {
        return a.i <= b.i;
    }
    public static VInt operator >>(VInt value, int moveCount)
    {
        if (value.i >= 0)
        {
            return new VInt(value.i >> moveCount);
        }
        else
        {
            return new VInt(-(-value.i >> moveCount));
        }

    }
    public static VInt operator <<(VInt value, int moveCount)
    {
        return new VInt(value.i << moveCount);
    }
}
