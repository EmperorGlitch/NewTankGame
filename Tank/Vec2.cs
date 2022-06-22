using GXPEngine;
using System;

public struct Vec2
{
	public float x;
	public float y;
	public Vec2(float pX = 0, float pY = 0)
	{
		x = pX;
		y = pY;
	}

	public static Vec2 operator +(Vec2 v1, Vec2 v2)
	{
		return new Vec2(v1.x + v2.x, v1.y + v2.y);
	}

	public static Vec2 operator -(Vec2 v1, Vec2 v2)
	{
		return new Vec2(v1.x - v2.x, v1.y - v2.y);
	}

	public override string ToString()
	{
		return String.Format("({0} ; {1})", x, y);
	}

	public float Length()
	{
		return Mathf.Sqrt(x * x + y * y);
	}

	public static Vec2 Lerp(Vec2 v1, Vec2 v2, float p)
	{
		float x = v1.x + (v2.x - v1.x) * p;
		float y = v1.y + (v2.y - v1.y) * p;

		return new Vec2(x, y);
	}

	public void Normalize()
	{
		float len = this.Length();
		this.x = x / len;
		this.y = y / len;
	}

	public Vec2 Normalized()
	{
		float len = this.Length();
		return new Vec2(x / len, y / len);
	}

	public static Vec2 operator *(Vec2 v1, float f1)
	{
		return new Vec2(v1.x * f1, v1.y * f1);
	}

	public static Vec2 operator *(float f1, Vec2 v1)
	{
		return v1 * f1;
	}

	public void SetXY(float x, float y)
	{
		this.x = x;
		this.y = y;
	}

	public static float Deg2Rad(float degrees)
	{
		return (Mathf.PI * degrees) / 180;
	}

	public static float Rad2Deg(float rads)
	{
		return rads * (180 / Mathf.PI);
	}

	public static Vec2 GetUnitVectorDeg(float deg)
	{
		float rad = Deg2Rad(deg);
		float y = Mathf.Cos(rad);
		float x = Mathf.Sin(rad);

		return new Vec2(x, y);
	}

	public static Vec2 GetUnitVectorRad(float rad)
	{
		float y = Mathf.Cos(rad);
		float x = Mathf.Sin(rad);

		return new Vec2(x, y);
	}

	public static Vec2 RandomUnitVector()
	{
		Random r = new Random();
		float rand = (float)r.NextDouble();
		float angle = 360 * rand;
		return GetUnitVectorDeg(angle);
	}
	
	public void setAngleRadians(float angle)
	{
		Vec2 v2 = Vec2.GetUnitVectorRad(angle) * Length();
		this = v2;
	}

	public void setAngleDegrees(float angle)
	{
		Vec2 v2 = Vec2.GetUnitVectorDeg(angle) * Length();
		this = v2;
	}

	public float getAngleRadians()
	{
		Vec2 v = Normalized();
		return Mathf.Atan2(v.y, v.x);
	}

	public float getAngleDegres()
	{
		return Rad2Deg(getAngleRadians());
	}

	public Vec2 rotateRadians(float angle)
	{
		float x = (this.x * Mathf.Cos(angle)) + (this.y * -Mathf.Sin(angle));
		float y = (this.x * Mathf.Sin(angle)) + (this.y * Mathf.Cos(angle));

		return new Vec2(x, y);
	}
	
	public Vec2 rotateDeegres(float angle)
	{
		float rad = Deg2Rad(angle);
		return rotateRadians(rad);
	}

	public void rotateAroundRadians(Vec2 target, float angle)
	{
		Vec2 temp = new Vec2(this.x - target.x, this.y - target.y);
		temp = temp.rotateRadians(angle);
		x = target.x + temp.x;
		y = target.y + temp.y;
	}

	public void rotateAroundDegres(Vec2 target, float angle)
	{
		float rad = Deg2Rad(angle);
		rotateAroundRadians(target, rad);
	}

	//Unit-test
	public static void Debug()
    {
		
		var v1 = new Vec2(1, 2);
		var v2 = new Vec2(3, 4);

		//Vec2 operator +
		Console.WriteLine("METHOD: operator+(v1, v2) INPUT: v1 = {0}, v2 = {1} \n", v1, v2);

		Console.WriteLine("OUTPUT: {0} \n \n", v1 + v2);

		//Vec2 operator -
		Console.WriteLine("METHOD: operator-(v1, v2) INPUT: v1 = {0}, v2 = {1} \n", v1, v2);

		Console.WriteLine("OUTPUT: {0} \n \n", v1 - v2);

		//float Length()
		Console.WriteLine("METHOD: Length(v1) INPUT: v1 = {0} \n", v1);

		Console.WriteLine("OUTPUT: {0} \n \n", v1.Length());

		//Vec2 Lerp(Vec2 v1, Vec2 v2, float p)
		Console.WriteLine("METHOD: Lerp(v1, v2, p) INPUT: v1 = {0}, v2 = {1}, p = {2} \n", v1, v2, 0.5f);

		Console.WriteLine("OUTPUT: {0} \n \n", Lerp(v1, v2, 0.5f));

		//void Normalize()
		var v3 = new Vec2(7, 10);
		Console.WriteLine("METHOD: Normalize(v3) INPUT: v3 = {0} \n", v3);

		v3.Normalize();
		Console.WriteLine("OUTPUT: {0} \n \n", v3);

		//Vec2 Normalized()
		Console.WriteLine("METHOD: Normalized(v1) INPUT: v1 = {0} \n", v1);

		Console.WriteLine("OUTPUT: {0} \n \n", v1.Normalized());

		//Vec2 operator *(Vec2 v1, float f1)
		Console.WriteLine("METHOD: operator*(v1, f1) INPUT: v1 = {0}, f1 = {1} \n", v1, 3.0f);

		Console.WriteLine("OUTPUT: {0} \n \n", v1 * 3.0f);

		//Vec2 operator *(float f1, Vec2 v1)
		Console.WriteLine("METHOD: operator*(f1, v1) INPUT: v1 = {0}, f1 = {1} \n", v1, 3.0f);

		Console.WriteLine("OUTPUT: {0} \n \n", 3.0f * v1);

		//void SetXY(float x, float y)
		Console.WriteLine("METHOD: SetXY(x, y) INPUT: x = {0}, y = {1} \n", 2.5f, 5.6f);

		v3.SetXY(2.5f, 5.6f);
		Console.WriteLine("OUTPUT: {0} \n \n", v3);

		//float Deg2Rad(float degrees)
		Console.WriteLine("METHOD: Deg2Rad(degrees) INPUT: degrees = {0} \n", 90.0f);

		Console.WriteLine("OUTPUT: {0} \n \n", Deg2Rad(90.0f));

		//float Rad2Deg(float rads)
		Console.WriteLine("METHOD: Rad2Deg(rads) INPUT: rads = {0} \n", 3.14f);

		Console.WriteLine("OUTPUT: {0} \n \n", Rad2Deg(3.14f));

		//Vec2 GetUnitVectorDeg(float deg)
		Console.WriteLine("METHOD: GetUnitVectorDeg(deg) INPUT: deg = {0} \n", 45.0f);

		Console.WriteLine("OUTPUT: {0} \n \n", GetUnitVectorDeg(45.0f));

		//Vec2 GetUnitVectorRad(float rad)
		Console.WriteLine("METHOD: GetUnitVectorRad(rad) INPUT: rad = {0} \n", Mathf.PI / 4);

		Console.WriteLine("OUTPUT: {0} \n \n", GetUnitVectorRad(Mathf.PI / 4));

		//Vec2 RandomUnitVector()
		Console.WriteLine("METHOD: RandomUnitVector() INPUT: none \n");

		Console.WriteLine("OUTPUT: {0} \n \n", RandomUnitVector());

		//void setAngleRadians(float angle)
		Console.WriteLine("METHOD: setAngleRadians(angle) INPUT: v2 = {0}, angle = Mathf.PI / 4  \n", v2);

		v2.setAngleRadians(Mathf.PI / 4);
		Console.WriteLine("OUTPUT: {0} \n \n", v2);

		//void setAngleDegrees(float angle)
		Console.WriteLine("METHOD: setAngleDegrees(angle) INPUT: v3 = {0}, angle = {1}  \n", v3, 45.0f);

		v3.setAngleDegrees(45.0f);
		Console.WriteLine("OUTPUT: {0} \n \n", v3);

		//float getAngleRadians()
		Console.WriteLine("METHOD: getAngleRadians() INPUT: v2 = {0}  \n", v2);

		Console.WriteLine("OUTPUT: {0} \n \n", v2.getAngleRadians());

		//float getAngleDegres()
		Console.WriteLine("METHOD: getAngleDegres() INPUT: v3 = {0}  \n", v3);

		Console.WriteLine("OUTPUT: {0} \n \n", v3.getAngleDegres());

		//Vec2 rotateRadians(float angle)
		Console.WriteLine("METHOD: rotateRadians(angle) INPUT: v3 = {0} , angle = {1}  \n", v3 , -1 * ( Mathf.PI / 4) );

		Console.WriteLine("OUTPUT: {0} \n \n", v3.rotateRadians(-1 * (Mathf.PI / 4)));

		//Vec2 rotateDeegres(float angle)
		Console.WriteLine("METHOD: rotateDeegres(angle) INPUT: v3 = {0} , angle = {1}  \n", v3, -45.0f);

		Console.WriteLine("OUTPUT: {0} \n \n", v3.rotateDeegres(-45.0f));

		//void rotateAroundRadians(Vec2 target, float angle)
		Console.WriteLine("METHOD: rotateAroundRadians(target, angle) INPUT: target = (1,2) , angle = (Mathf.PI / 4) \n" );

		v3.rotateAroundRadians(new Vec2(1, 2), (Mathf.PI / 4));
		Console.WriteLine("OUTPUT: {0} \n \n", v3);

		//void rotateAroundDegres(Vec2 target, float angle)
		Console.WriteLine("METHOD: rotateAroundDegres(target, angle) INPUT: target = (1,2) , angle = 45.0f \n");

		v3.rotateAroundDegres(new Vec2(1, 2), 45.0f);
		Console.WriteLine("OUTPUT: {0} \n \n", v3);


		//
		System.GC.Collect();

		Console.WriteLine("\nPress enter to quit");
		Console.ReadLine();

		
	}
}