using UnityEngine;

public static class AudioUtils
{
    /// <summary>
    /// ����������� ������� ��������� � ���������, �������������� Unity Audio Mixer.
    /// ���� ����� �������� ���� ��������� �����������.
    /// </summary>
    public const float MinDecibels = -80f;

    /// <summary>
    /// ����������� ��� �������������� ��������� (�������� ���������) � ��������.
    /// ������������ 20, ������ ��� dB = 20 * log10(amplitude).
    /// </summary>
    private const float AmplitudeToDecibelFactor = 20f;

    /// <summary>
    /// ��������� ��������� ��� ��������� �������������� (10, ��� ��� ������������ log10).
    /// </summary>
    private const float LogBase = 10f;

    private static readonly float MinLinear = DecibelsToLinear(MinDecibels);

    public static float LinearToDecibels(float linear)
    {
        if (linear <= MinLinear)
            return MinDecibels;

        return Mathf.Log10(linear) * AmplitudeToDecibelFactor;
    }

    public static float DecibelsToLinear(float dB)
    {
        if (dB <= MinDecibels)
            return 0f;

        return Mathf.Pow(LogBase, dB / AmplitudeToDecibelFactor);
    }
}