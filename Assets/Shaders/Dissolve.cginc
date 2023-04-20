// URP Dissolve 2020 | VFX Shaders | Unity Asset Store
// https://assetstore.unity.com/packages/vfx/shaders/urp-dissolve-2020-191256
float2 TilingAndOffset(float2 UV, float2 Tiling, float2 Offset)
{
	return UV * Tiling + Offset;
}

float2 UVSpeed(float2 UV, float2 UVSpeed)
{
	return UV + (UVSpeed * (_Time * 0.005));
}

float NoiseRandomValue(float2 UV)
{
	return frac(sin(dot(UV, float2(12.9898, 78.233))) * 43758.5453);
}

float NoiseInterpolate(float A, float B, float T)
{
	return (1.0 - T) * A + (T * B);
}

float ValueNoise(float2 UV)
{
    float2 i = floor(UV);
    float2 f = frac(UV);
    f = f * f * (3.0 - 2.0 * f);

    UV = abs(frac(UV) - 0.5);
    float2 c0 = i + float2(0.0, 0.0);
    float2 c1 = i + float2(1.0, 0.0);
    float2 c2 = i + float2(0.0, 1.0);
    float2 c3 = i + float2(1.0, 1.0);
    float r0 = NoiseRandomValue(c0);
    float r1 = NoiseRandomValue(c1);
    float r2 = NoiseRandomValue(c2);
    float r3 = NoiseRandomValue(c3);

    float bottomOfGrid = NoiseInterpolate(r0, r1, f.x);
    float topOfGrid = NoiseInterpolate(r2, r3, f.x);
    float t = NoiseInterpolate(bottomOfGrid, topOfGrid, f.y);
    return t;
}

float SimpleNoise(float2 UV, float Scale)
{
    float t = 0.0;

    float freq = pow(2.0, float(0));
    float amp = pow(0.5, float(3 - 0));
    t += ValueNoise(float2(UV.x * Scale / freq, UV.y * Scale / freq)) * amp;

    freq = pow(2.0, float(1));
    amp = pow(0.5, float(3 - 1));
    t += ValueNoise(float2(UV.x * Scale / freq, UV.y * Scale / freq)) * amp;

    freq = pow(2.0, float(2));
    amp = pow(0.5, float(3 - 2));
    t += ValueNoise(float2(UV.x * Scale / freq, UV.y * Scale / freq)) * amp;

    return t;
}
