namespace Application.Features
{
    public abstract class BaseDTO
    {
        public enum ValidResources
        {
            NONE = 0,
            ALL = 11,
            BERRY = 21,
            BERRY_FIRMNESS = 22,
            BERRY_FLAVOR = 23,
            CONTEST_TYPE = 31,
            CONTEST_EFFECT = 32,
            SUPER_CONTEST_EFFECT = 33,
            ENCOUNTER_METHOD = 41,
            ENCOUNTER_CONDITION = 42,
            ENCOUNTER_CONDITION_VALUE = 43,
            EVOLUTION_CHAIN = 51,
            EVOLUTION_TRIGGER = 52,
            GENERATION = 61,
            POKEDEX = 62,
            VERSION = 63,
            VERSION_GROUP = 64,
            ITEM = 71,
            ITEM_ATTRIBUTE = 72,
            ITEM_CATEGORY = 73,
            ITEM_FIRMNESS = 74,
            ITEM_POCKET = 75,
            LOCATION = 81,
            LOCATION_AREA = 82,
            PAL_PARK_AREA = 83,
            REGION = 84,
            MACHINE = 91,
            MOVE = 101,
            MOVE_AILMENT = 102,
            MOVE_BATTLE_STYLE = 103,
            MOVE_CATEGORY = 104,
            MOVE_DAMAGE_CLASS = 105,
            MOVE_LEARN_METHOD = 106,
            MOVE_TARGET = 107,
            ABILITY = 111,
            CHARACTERISTIC = 112,
            EGG_GROUP = 113,
            GENDER = 114,
            GROWTH_RATE = 115,
            NATURE = 116,
            POKEATHLON_STAT = 117,
            POKEMON = 118,
            ENCOUNTERS = 119,
            POKEMON_COLOR = 120,
            POKEMON_FORM = 121,
            POKEMON_HABITAT = 122,
            POKEMON_SHAPE = 123,
            POKEMON_SPECIES = 124,
            STAT = 125,
            TYPE = 126,
            LANGUAGE = 131
        }

        public static ValidResources GetResourceValue(string _resource)
        {
            foreach (ValidResources resource in Enum.GetValues(typeof(ValidResources)))
            {
                if (resource.ToString().Equals(_resource, StringComparison.OrdinalIgnoreCase))
                {
                    return resource;
                }
            }

            return ValidResources.NONE;
        }
    }
}

