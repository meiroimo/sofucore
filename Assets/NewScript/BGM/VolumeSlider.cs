using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

/// <summary>
/// ���ʃX���C�_�[
/// </summary>
[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    /// <summary>
    /// �I�[�f�B�I�~�L�T�[
    /// </summary>
    [SerializeField]
    private AudioMixer _mixer = null;

    /// <summary>
    /// ���ʃp�����[�^��
    /// </summary>
    [SerializeField]
    private string _parameterName = string.Empty;


    /// <summary>
    /// �X���C�_�[
    /// </summary>
    private Slider _slider = null;


    private void Reset()
    {
        var slider = GetComponent<Slider>();
        slider.minValue = 0f;
        slider.maxValue = 1f;
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _mixer.GetFloat(_parameterName, out float mixerVolume);
        _slider.value = Db2Pa(mixerVolume);
        _slider.onValueChanged.AddListener((sliderValue) => _mixer.SetFloat(_parameterName, Pa2Db(sliderValue)));
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveAllListeners();
    }


    /// <summary>
    /// �f�V�x���ϊ�
    /// 0, 1, 10�̉�����-80, 0, 20�̃f�V�x��
    /// </summary>
    /// <param name="pa"></param>
    /// <returns></returns>
    private float Pa2Db(float pa)
    {
        pa = Mathf.Clamp(pa, 0.0001f, 10f);
        return 20f * Mathf.Log10(pa);
    }

    /// <summary>
    /// �����ϊ�
    /// -80, 0, 20�̃f�V�x����0, 1, 10�̉���
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    private float Db2Pa(float db)
    {
        db = Mathf.Clamp(db, -80f, 20f);
        return Mathf.Pow(10f, db / 20f);
    }
}