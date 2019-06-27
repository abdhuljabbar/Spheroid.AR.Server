/*
 *  Copyright (c) 2019 Spheroid Universe
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

namespace Spheroid.AR
{
    public readonly struct Height
    {
        public float Value { get; }
        public HeightOptions Options { get; }

        public HeightRelativity Relativity => Options.Relativity;
        public HeightAlignment Alignment => Options.Alignment;
        public bool IsDefaultValue => Options.IsDefaultValue;

        public Height(float value, HeightOptions options)
        {
            Value = value;
            Options = options;
        }
    }
}
