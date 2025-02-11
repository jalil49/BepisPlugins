﻿using HarmonyLib;
using System.Collections.Generic;
using static ExtensibleSaveFormat.ExtendedSave;
#if AI || HS2
using AIChara;
#endif


namespace ExtensibleSaveFormat
{
    public static class Extensions
    {
        private static Dictionary<string, PluginData> GetAllExtendedData(object messagePackObject)
        {
            try
            {
                if (messagePackObject == null) throw new System.ArgumentNullException(nameof(messagePackObject));

                var tv = Traverse.Create(messagePackObject);
                var prop = tv.Property(ExtendedSaveDataPropertyName);

                if (!prop.PropertyExists())
                    throw new System.NotSupportedException($"The type '{messagePackObject?.GetType()}' does not have the '{ExtendedSaveDataPropertyName}' property. Make sure the extended save patcher is installed and working.");

                var bytes = (byte[])prop.GetValue();
                if (bytes != null)
                {
                    return MessagePackDeserialize<Dictionary<string, PluginData>>(bytes);
                }
            }
            catch (System.Exception ex)
            {
                Logger.LogError(ex);
            }
            return null;
        }

        private static bool GetExtendedData(object messagePackObject, string id, out PluginData data)
        {
            Dictionary<string, PluginData> pluginData = GetAllExtendedData(messagePackObject);

            if (pluginData != null && pluginData.TryGetValue(id, out data))
                return true;
            data = null;
            return false;
        }

        private static void SetExtendedData(object messagePackObject, string id, PluginData data)
        {
            Dictionary<string, PluginData> pluginData = GetAllExtendedData(messagePackObject);

            try
            {
                if (pluginData == null) pluginData = new Dictionary<string, PluginData>();
                pluginData[id] = data;
                var bytes = MessagePackSerialize(pluginData);

                Traverse.Create(messagePackObject).Property(ExtendedSaveDataPropertyName).SetValue(bytes);
            }
            catch (System.Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        //Coordinate
        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileCoordinate messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileCoordinate messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileCoordinate messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

#if KK || KKS || EC         
        //Body
        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileBody messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileBody messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileBody messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        //Face
        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileFace messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileFace messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileFace messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileFace.PupilInfo messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileFace.PupilInfo messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileFace.PupilInfo messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        //Hair
        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileHair messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileHair messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileHair messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileHair.PartsInfo messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileHair.PartsInfo messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileHair.PartsInfo messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        //Clothes
        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileClothes messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileClothes messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileClothes messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileClothes.PartsInfo messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileClothes.PartsInfo messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileClothes.PartsInfo messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileClothes.PartsInfo.ColorInfo messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileClothes.PartsInfo.ColorInfo messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileClothes.PartsInfo.ColorInfo messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        //Accessory
        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileAccessory messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileAccessory messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileAccessory messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileAccessory.PartsInfo messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileAccessory.PartsInfo messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileAccessory.PartsInfo messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileStatus messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileStatus messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileStatus messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileParameter messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileParameter messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileParameter messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);
#endif

#if KK || KKS
        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileMakeup messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileMakeup messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileMakeup messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileParameter.Attribute messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileParameter.Attribute messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileParameter.Attribute messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileParameter.Awnser messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileParameter.Awnser messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileParameter.Awnser messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileParameter.Denial messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileParameter.Denial messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileParameter.Denial messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);
#endif

#if KKS
        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileAbout messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileAbout messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileAbout messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileParameter.Interest messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileParameter.Interest messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileParameter.Interest messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);
#endif

#if EC
        public static Dictionary<string, PluginData> GetAllExtendedData(this ChaFileFace.ChaFileMakeup messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this ChaFileFace.ChaFileMakeup messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this ChaFileFace.ChaFileMakeup messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);
#endif

#if AI || HS2
        //Body
        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileBody messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileBody messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileBody messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        //Face
        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileFace messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileFace messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileFace messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileFace.EyesInfo messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileFace.EyesInfo messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileFace.EyesInfo messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileFace.MakeupInfo messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileFace.MakeupInfo messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileFace.MakeupInfo messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        //Hair
        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileHair messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileHair messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileHair messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileHair.PartsInfo messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileHair.PartsInfo messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileHair.PartsInfo messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileHair.PartsInfo.BundleInfo messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileHair.PartsInfo.BundleInfo messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileHair.PartsInfo.BundleInfo messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileHair.PartsInfo.ColorInfo messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileHair.PartsInfo.ColorInfo messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileHair.PartsInfo.ColorInfo messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        //Clothes
        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileClothes messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileClothes messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileClothes messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileClothes.PartsInfo messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileClothes.PartsInfo messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileClothes.PartsInfo messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileClothes.PartsInfo.ColorInfo messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileClothes.PartsInfo.ColorInfo messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileClothes.PartsInfo.ColorInfo messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        //Accessory
        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileAccessory messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileAccessory messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileAccessory messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileAccessory.PartsInfo messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileAccessory.PartsInfo messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileAccessory.PartsInfo messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileAccessory.PartsInfo.ColorInfo messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileAccessory.PartsInfo.ColorInfo messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileAccessory.PartsInfo.ColorInfo messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileGameInfo messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileGameInfo messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileGameInfo messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileGameInfo.MinMaxInfo messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileGameInfo.MinMaxInfo messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileGameInfo.MinMaxInfo messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileParameter messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileParameter messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileParameter messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileStatus messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileStatus messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileStatus messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);
#endif

#if HS2
        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileGameInfo2 messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileGameInfo2 messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileGameInfo2 messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);

        public static Dictionary<string, PluginData> GetAllExtendedData(this AIChara.ChaFileParameter2 messagePackObject) => GetAllExtendedData(messagePackObject);
        public static bool TryGetExtendedDataById(this AIChara.ChaFileParameter2 messagePackObject, string id, out PluginData data) => GetExtendedData(messagePackObject, id, out data);
        public static void SetExtendedDataById(this AIChara.ChaFileParameter2 messagePackObject, string id, PluginData data) => SetExtendedData(messagePackObject, id, data);
#endif
    }
}
