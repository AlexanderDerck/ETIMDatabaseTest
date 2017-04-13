using ETIMDatabase.Entities;
using EtimIXF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ETIMDatabase
{
    internal class ETIM6XmlInitializer : DropCreateDatabaseIfModelChanges<EtimDB>
    {
        private readonly string etimXmlPath;

        public ETIM6XmlInitializer(string etimXmlPath)
        {
            this.etimXmlPath = etimXmlPath;
        }

        protected override void Seed(EtimDB context)
        {
            var serializer = new XmlSerializer(typeof(IXFType));
            IXFType ixf;

            using (var fs = new FileStream(etimXmlPath, FileMode.Open))
            {
                ixf = (IXFType)serializer.Deserialize(fs);
            }

            context.Groups.AddRange(CreateGroups(ixf.Groups));
            context.Classes.AddRange(CreateClasses(ixf.Classes));
            context.Features.AddRange(CreateFeatures(ixf.Features));
            context.Units.AddRange(CreateUnits(ixf.Units));
            context.Values.AddRange(CreateValues(ixf.Values));

            base.Seed(context);
        }

        private IEnumerable<EtimGroup> CreateGroups(IEnumerable<GroupType> xmlGroups)
        {
            foreach(var xmlGroup in xmlGroups)
            {
                EtimGroup group = new EtimGroup { Code = int.Parse(xmlGroup.Code.Substring(2)) };
                group.Translations = xmlGroup.Translations.Select(t => new EtimGroupTranslation(t)).ToList();

                yield return group;
            }
        }
        /// <summary>
        /// Create the Classes, ClassTranslations. Also create the mapping relations ClassFeature
        /// and ClassFeatureValue between Class and Feature.
        /// </summary>
        private IEnumerable<EtimClass> CreateClasses(IEnumerable<ClassType> xmlClasses)
        {
            foreach (var xmlClass in xmlClasses)
            {
                EtimClass @class = new EtimClass(xmlClass);
                List<EtimClassTranslation> translations = new List<EtimClassTranslation>();

                foreach(var translation in xmlClass.Translations)
                {
                    translations.Add(new EtimClassTranslation(translation.Description, translation.language, false));

                    if (translation.Synonyms != null)
                    {
                        foreach (var synonym in translation.Synonyms)
                            translations.Add(new EtimClassTranslation(synonym, translation.language, true));
                    }
                }

                @class.Translations = translations;
                @class.ClassFeatures = xmlClass.Features?.Select(f => new EtimClassFeature(f)).ToList();

                yield return @class;
            }
        }
        private IEnumerable<EtimFeature> CreateFeatures(IEnumerable<EtimIXF.FeatureType> xmlFeatures)
        {
            foreach (var xmlFeature in xmlFeatures)
            {
                EtimFeature feature = new EtimFeature { Code = int.Parse(xmlFeature.Code.Substring(2)) };
                feature.Translations = xmlFeature.Translations.Select(t => new EtimFeatureTranslation(t)).ToList();

                yield return feature;
            }
        }
        private IEnumerable<EtimUnit> CreateUnits(IEnumerable<UnitType> xmlUnits)
        {
            foreach(var xmlUnit in xmlUnits)
            {
                EtimUnit unit = new EtimUnit { Code = int.Parse(xmlUnit.Code.Substring(2)) };
                unit.Translations = xmlUnit.Translations.Select(t => new EtimUnitTranslation(t)).ToList();

                yield return unit;
            }
        }
        private IEnumerable<EtimValue> CreateValues(IEnumerable<EtimIXF.ValueType> xmlValues)
        {
            foreach(var xmlValue in xmlValues)
            {
                EtimValue value = new EtimValue { Code = int.Parse(xmlValue.Code.Substring(2)) };
                value.Translations = xmlValue.Translations.Select(t => new EtimValueTranslation(t)).ToList();

                yield return value;
            }
        }
    }
}
