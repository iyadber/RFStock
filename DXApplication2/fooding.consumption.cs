﻿// This file was auto-generated by ML.NET Model Builder.
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace DXApplication2
{
    public partial class Fooding
    {
        /// <summary>
        /// model input class for Fooding.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [LoadColumn(0)]
            [ColumnName(@"month")]
            public string Month { get; set; }

            [LoadColumn(1)]
            [ColumnName(@"vacance")]
            public float Vacance { get; set; }

            [LoadColumn(2)]
            [ColumnName(@"nom")]
            public string Nom { get; set; }

            [LoadColumn(3)]
            [ColumnName(@"qt")]
            public float Qt { get; set; }

            [LoadColumn(4)]
            [ColumnName(@"n")]
            public float N { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for Fooding.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"month")]
            public float[] Month { get; set; }

            [ColumnName(@"vacance")]
            public float Vacance { get; set; }

            [ColumnName(@"nom")]
            public float[] Nom { get; set; }

            [ColumnName(@"qt")]
            public float Qt { get; set; }

            [ColumnName(@"n")]
            public float N { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"Score")]
            public float Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("fooding.mlnet");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);


        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }
    }
}
