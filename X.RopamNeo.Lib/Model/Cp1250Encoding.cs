// Type: X.RopamNeo.Lib.Model.Cp1250Encoding

using System.Collections.Generic;
using System.Text;

namespace X.RopamNeo.Lib.Model
{
    public class Cp1250Encoding : Encoding
    {
        private char? fallbackCharacter;

        private static char[] byteToChar = new char[256]
        {
      char.MinValue,
      '\u0001',
      '\u0002',
      '\u0003',
      '\u0004',
      '\u0005',
      '\u0006',
      '\a',
      '\b',
      '\t',
      '\n',
      '\v',
      '\f',
      '\r',
      '\u000E',
      '\u000F',
      '\u0010',
      '\u0011',
      '\u0012',
      '\u0013',
      '\u0014',
      '\u0015',
      '\u0016',
      '\u0017',
      '\u0018',
      '\u0019',
      '\u001A',
      '\u001B',
      '\u001C',
      '\u001D',
      '\u001E',
      '\u001F',
      ' ',
      '!',
      '"',
      '#',
      '$',
      '%',
      '&',
      '\'',
      '(',
      ')',
      '*',
      '+',
      ',',
      '-',
      '.',
      '/',
      '0',
      '1',
      '2',
      '3',
      '4',
      '5',
      '6',
      '7',
      '8',
      '9',
      ':',
      ';',
      '<',
      '=',
      '>',
      '?',
      '@',
      'A',
      'B',
      'C',
      'D',
      'E',
      'F',
      'G',
      'H',
      'I',
      'J',
      'K',
      'L',
      'M',
      'N',
      'O',
      'P',
      'Q',
      'R',
      'S',
      'T',
      'U',
      'V',
      'W',
      'X',
      'Y',
      'Z',
      '[',
      '\\',
      ']',
      '^',
      '_',
      '`',
      'a',
      'b',
      'c',
      'd',
      'e',
      'f',
      'g',
      'h',
      'i',
      'j',
      'k',
      'l',
      'm',
      'n',
      'o',
      'p',
      'q',
      'r',
      's',
      't',
      'u',
      'v',
      'w',
      'x',
      'y',
      'z',
      '{',
      '|',
      '}',
      '~',
      '\u007F',
      '€',
      '\u0081',
      '‚',
      '\u0083',
      '„',
      '…',
      '†',
      '‡',
      '\u0088',
      '‰',
      'Š',
      '‹',
      'Ś',
      'Ť',
      'Ž',
      'Ź',
      '\u0090',
      '‘',
      '’',
      '“',
      '”',
      '•',
      '–',
      '—',
      '\u0098',
      '™',
      'š',
      '›',
      'ś',
      'ť',
      'ž',
      'ź',
      ' ',
      'ˇ',
      '˘',
      'Ł',
      '¤',
      'Ą',
      '¦',
      '§',
      '¨',
      '©',
      'Ş',
      '«',
      '¬',
      '\u00AD',
      '®',
      'Ż',
      '°',
      '±',
      '˛',
      'ł',
      '´',
      'µ',
      '¶',
      '·',
      '¸',
      'ą',
      'ş',
      '»',
      'Ľ',
      '˝',
      'ľ',
      'ż',
      'Ŕ',
      'Á',
      'Â',
      'Ă',
      'Ä',
      'Ĺ',
      'Ć',
      'Ç',
      'Č',
      'É',
      'Ę',
      'Ë',
      'Ě',
      'Í',
      'Î',
      'Ď',
      'Đ',
      'Ń',
      'Ň',
      'Ó',
      'Ô',
      'Ő',
      'Ö',
      '×',
      'Ř',
      'Ů',
      'Ú',
      'Ű',
      'Ü',
      'Ý',
      'Ţ',
      'ß',
      'ŕ',
      'á',
      'â',
      'ă',
      'ä',
      'ĺ',
      'ć',
      'ç',
      'č',
      'é',
      'ę',
      'ë',
      'ě',
      'í',
      'î',
      'ď',
      'đ',
      'ń',
      'ň',
      'ó',
      'ô',
      'ő',
      'ö',
      '÷',
      'ř',
      'ů',
      'ú',
      'ű',
      'ü',
      'ý',
      'ţ',
      '˙'
        };

        private static Dictionary<char, byte> charToByte = new Dictionary<char, byte>()
    {
      {
        char.MinValue,
        (byte) 0
      },
      {
        '\u0001',
        (byte) 1
      },
      {
        '\u0002',
        (byte) 2
      },
      {
        '\u0003',
        (byte) 3
      },
      {
        '\u0004',
        (byte) 4
      },
      {
        '\u0005',
        (byte) 5
      },
      {
        '\u0006',
        (byte) 6
      },
      {
        '\a',
        (byte) 7
      },
      {
        '\b',
        (byte) 8
      },
      {
        '\t',
        (byte) 9
      },
      {
        '\n',
        (byte) 10
      },
      {
        '\v',
        (byte) 11
      },
      {
        '\f',
        (byte) 12
      },
      {
        '\r',
        (byte) 13
      },
      {
        '\u000E',
        (byte) 14
      },
      {
        '\u000F',
        (byte) 15
      },
      {
        '\u0010',
        (byte) 16
      },
      {
        '\u0011',
        (byte) 17
      },
      {
        '\u0012',
        (byte) 18
      },
      {
        '\u0013',
        (byte) 19
      },
      {
        '\u0014',
        (byte) 20
      },
      {
        '\u0015',
        (byte) 21
      },
      {
        '\u0016',
        (byte) 22
      },
      {
        '\u0017',
        (byte) 23
      },
      {
        '\u0018',
        (byte) 24
      },
      {
        '\u0019',
        (byte) 25
      },
      {
        '\u001A',
        (byte) 26
      },
      {
        '\u001B',
        (byte) 27
      },
      {
        '\u001C',
        (byte) 28
      },
      {
        '\u001D',
        (byte) 29
      },
      {
        '\u001E',
        (byte) 30
      },
      {
        '\u001F',
        (byte) 31
      },
      {
        ' ',
        (byte) 32
      },
      {
        '!',
        (byte) 33
      },
      {
        '"',
        (byte) 34
      },
      {
        '#',
        (byte) 35
      },
      {
        '$',
        (byte) 36
      },
      {
        '%',
        (byte) 37
      },
      {
        '&',
        (byte) 38
      },
      {
        '\'',
        (byte) 39
      },
      {
        '(',
        (byte) 40
      },
      {
        ')',
        (byte) 41
      },
      {
        '*',
        (byte) 42
      },
      {
        '+',
        (byte) 43
      },
      {
        ',',
        (byte) 44
      },
      {
        '-',
        (byte) 45
      },
      {
        '.',
        (byte) 46
      },
      {
        '/',
        (byte) 47
      },
      {
        '0',
        (byte) 48
      },
      {
        '1',
        (byte) 49
      },
      {
        '2',
        (byte) 50
      },
      {
        '3',
        (byte) 51
      },
      {
        '4',
        (byte) 52
      },
      {
        '5',
        (byte) 53
      },
      {
        '6',
        (byte) 54
      },
      {
        '7',
        (byte) 55
      },
      {
        '8',
        (byte) 56
      },
      {
        '9',
        (byte) 57
      },
      {
        ':',
        (byte) 58
      },
      {
        ';',
        (byte) 59
      },
      {
        '<',
        (byte) 60
      },
      {
        '=',
        (byte) 61
      },
      {
        '>',
        (byte) 62
      },
      {
        '?',
        (byte) 63
      },
      {
        '@',
        (byte) 64
      },
      {
        'A',
        (byte) 65
      },
      {
        'B',
        (byte) 66
      },
      {
        'C',
        (byte) 67
      },
      {
        'D',
        (byte) 68
      },
      {
        'E',
        (byte) 69
      },
      {
        'F',
        (byte) 70
      },
      {
        'G',
        (byte) 71
      },
      {
        'H',
        (byte) 72
      },
      {
        'I',
        (byte) 73
      },
      {
        'J',
        (byte) 74
      },
      {
        'K',
        (byte) 75
      },
      {
        'L',
        (byte) 76
      },
      {
        'M',
        (byte) 77
      },
      {
        'N',
        (byte) 78
      },
      {
        'O',
        (byte) 79
      },
      {
        'P',
        (byte) 80
      },
      {
        'Q',
        (byte) 81
      },
      {
        'R',
        (byte) 82
      },
      {
        'S',
        (byte) 83
      },
      {
        'T',
        (byte) 84
      },
      {
        'U',
        (byte) 85
      },
      {
        'V',
        (byte) 86
      },
      {
        'W',
        (byte) 87
      },
      {
        'X',
        (byte) 88
      },
      {
        'Y',
        (byte) 89
      },
      {
        'Z',
        (byte) 90
      },
      {
        '[',
        (byte) 91
      },
      {
        '\\',
        (byte) 92
      },
      {
        ']',
        (byte) 93
      },
      {
        '^',
        (byte) 94
      },
      {
        '_',
        (byte) 95
      },
      {
        '`',
        (byte) 96
      },
      {
        'a',
        (byte) 97
      },
      {
        'b',
        (byte) 98
      },
      {
        'c',
        (byte) 99
      },
      {
        'd',
        (byte) 100
      },
      {
        'e',
        (byte) 101
      },
      {
        'f',
        (byte) 102
      },
      {
        'g',
        (byte) 103
      },
      {
        'h',
        (byte) 104
      },
      {
        'i',
        (byte) 105
      },
      {
        'j',
        (byte) 106
      },
      {
        'k',
        (byte) 107
      },
      {
        'l',
        (byte) 108
      },
      {
        'm',
        (byte) 109
      },
      {
        'n',
        (byte) 110
      },
      {
        'o',
        (byte) 111
      },
      {
        'p',
        (byte) 112
      },
      {
        'q',
        (byte) 113
      },
      {
        'r',
        (byte) 114
      },
      {
        's',
        (byte) 115
      },
      {
        't',
        (byte) 116
      },
      {
        'u',
        (byte) 117
      },
      {
        'v',
        (byte) 118
      },
      {
        'w',
        (byte) 119
      },
      {
        'x',
        (byte) 120
      },
      {
        'y',
        (byte) 121
      },
      {
        'z',
        (byte) 122
      },
      {
        '{',
        (byte) 123
      },
      {
        '|',
        (byte) 124
      },
      {
        '}',
        (byte) 125
      },
      {
        '~',
        (byte) 126
      },
      {
        '\u007F',
        (byte) 127
      },
      {
        '€',
        (byte) 128
      },
      {
        '\u0081',
        (byte) 129
      },
      {
        '‚',
        (byte) 130
      },
      {
        '\u0083',
        (byte) 131
      },
      {
        '„',
        (byte) 132
      },
      {
        '…',
        (byte) 133
      },
      {
        '†',
        (byte) 134
      },
      {
        '‡',
        (byte) 135
      },
      {
        '\u0088',
        (byte) 136
      },
      {
        '‰',
        (byte) 137
      },
      {
        'Š',
        (byte) 138
      },
      {
        '‹',
        (byte) 139
      },
      {
        'Ś',
        (byte) 140
      },
      {
        'Ť',
        (byte) 141
      },
      {
        'Ž',
        (byte) 142
      },
      {
        'Ź',
        (byte) 143
      },
      {
        '\u0090',
        (byte) 144
      },
      {
        '‘',
        (byte) 145
      },
      {
        '’',
        (byte) 146
      },
      {
        '“',
        (byte) 147
      },
      {
        '”',
        (byte) 148
      },
      {
        '•',
        (byte) 149
      },
      {
        '–',
        (byte) 150
      },
      {
        '—',
        (byte) 151
      },
      {
        '\u0098',
        (byte) 152
      },
      {
        '™',
        (byte) 153
      },
      {
        'š',
        (byte) 154
      },
      {
        '›',
        (byte) 155
      },
      {
        'ś',
        (byte) 156
      },
      {
        'ť',
        (byte) 157
      },
      {
        'ž',
        (byte) 158
      },
      {
        'ź',
        (byte) 159
      },
      {
        ' ',
        (byte) 160
      },
      {
        'ˇ',
        (byte) 161
      },
      {
        '˘',
        (byte) 162
      },
      {
        'Ł',
        (byte) 163
      },
      {
        '¤',
        (byte) 164
      },
      {
        'Ą',
        (byte) 165
      },
      {
        '¦',
        (byte) 166
      },
      {
        '§',
        (byte) 167
      },
      {
        '¨',
        (byte) 168
      },
      {
        '©',
        (byte) 169
      },
      {
        'Ş',
        (byte) 170
      },
      {
        '«',
        (byte) 171
      },
      {
        '¬',
        (byte) 172
      },
      {
        '\u00AD',
        (byte) 173
      },
      {
        '®',
        (byte) 174
      },
      {
        'Ż',
        (byte) 175
      },
      {
        '°',
        (byte) 176
      },
      {
        '±',
        (byte) 177
      },
      {
        '˛',
        (byte) 178
      },
      {
        'ł',
        (byte) 179
      },
      {
        '´',
        (byte) 180
      },
      {
        'µ',
        (byte) 181
      },
      {
        '¶',
        (byte) 182
      },
      {
        '·',
        (byte) 183
      },
      {
        '¸',
        (byte) 184
      },
      {
        'ą',
        (byte) 185
      },
      {
        'ş',
        (byte) 186
      },
      {
        '»',
        (byte) 187
      },
      {
        'Ľ',
        (byte) 188
      },
      {
        '˝',
        (byte) 189
      },
      {
        'ľ',
        (byte) 190
      },
      {
        'ż',
        (byte) 191
      },
      {
        'Ŕ',
        (byte) 192
      },
      {
        'Á',
        (byte) 193
      },
      {
        'Â',
        (byte) 194
      },
      {
        'Ă',
        (byte) 195
      },
      {
        'Ä',
        (byte) 196
      },
      {
        'Ĺ',
        (byte) 197
      },
      {
        'Ć',
        (byte) 198
      },
      {
        'Ç',
        (byte) 199
      },
      {
        'Č',
        (byte) 200
      },
      {
        'É',
        (byte) 201
      },
      {
        'Ę',
        (byte) 202
      },
      {
        'Ë',
        (byte) 203
      },
      {
        'Ě',
        (byte) 204
      },
      {
        'Í',
        (byte) 205
      },
      {
        'Î',
        (byte) 206
      },
      {
        'Ď',
        (byte) 207
      },
      {
        'Đ',
        (byte) 208
      },
      {
        'Ń',
        (byte) 209
      },
      {
        'Ň',
        (byte) 210
      },
      {
        'Ó',
        (byte) 211
      },
      {
        'Ô',
        (byte) 212
      },
      {
        'Ő',
        (byte) 213
      },
      {
        'Ö',
        (byte) 214
      },
      {
        '×',
        (byte) 215
      },
      {
        'Ř',
        (byte) 216
      },
      {
        'Ů',
        (byte) 217
      },
      {
        'Ú',
        (byte) 218
      },
      {
        'Ű',
        (byte) 219
      },
      {
        'Ü',
        (byte) 220
      },
      {
        'Ý',
        (byte) 221
      },
      {
        'Ţ',
        (byte) 222
      },
      {
        'ß',
        (byte) 223
      },
      {
        'ŕ',
        (byte) 224
      },
      {
        'á',
        (byte) 225
      },
      {
        'â',
        (byte) 226
      },
      {
        'ă',
        (byte) 227
      },
      {
        'ä',
        (byte) 228
      },
      {
        'ĺ',
        (byte) 229
      },
      {
        'ć',
        (byte) 230
      },
      {
        'ç',
        (byte) 231
      },
      {
        'č',
        (byte) 232
      },
      {
        'é',
        (byte) 233
      },
      {
        'ę',
        (byte) 234
      },
      {
        'ë',
        (byte) 235
      },
      {
        'ě',
        (byte) 236
      },
      {
        'í',
        (byte) 237
      },
      {
        'î',
        (byte) 238
      },
      {
        'ď',
        (byte) 239
      },
      {
        'đ',
        (byte) 240
      },
      {
        'ń',
        (byte) 241
      },
      {
        'ň',
        (byte) 242
      },
      {
        'ó',
        (byte) 243
      },
      {
        'ô',
        (byte) 244
      },
      {
        'ő',
        (byte) 245
      },
      {
        'ö',
        (byte) 246
      },
      {
        '÷',
        (byte) 247
      },
      {
        'ř',
        (byte) 248
      },
      {
        'ů',
        (byte) 249
      },
      {
        'ú',
        (byte) 250
      },
      {
        'ű',
        (byte) 251
      },
      {
        'ü',
        (byte) 252
      },
      {
        'ý',
        (byte) 253
      },
      {
        'ţ',
        (byte) 254
      },
      {
        '˙',
        byte.MaxValue
      }
    };

        public override string WebName => "windows-1250";

        public char? FallbackCharacter
        {
            get => this.fallbackCharacter;
            set
            {
                this.fallbackCharacter = value;
                if (value.HasValue && !Cp1250Encoding.charToByte.ContainsKey(value.Value))
                    throw new EncoderFallbackException(string.Format("Cannot use the character [{0}] (int value {1}) as fallback value - the fallback character itself is not supported by the encoding.", (object)value.Value, (object)(int)value.Value));
                this.FallbackByte = value.HasValue ? new byte?(Cp1250Encoding.charToByte[value.Value]) : new byte?();
            }
        }

        public byte? FallbackByte { get; private set; }

        public Cp1250Encoding() => this.FallbackCharacter = new char?('?');

        public override int GetBytes(
          char[] chars,
          int charIndex,
          int charCount,
          byte[] bytes,
          int byteIndex)
        {
            return !this.FallbackByte.HasValue ? this.GetBytesWithoutFallback(chars, charIndex, charCount, bytes, byteIndex) : this.GetBytesWithFallBack(chars, charIndex, charCount, bytes, byteIndex);
        }

        private int GetBytesWithFallBack(
          char[] chars,
          int charIndex,
          int charCount,
          byte[] bytes,
          int byteIndex)
        {
            for (int index = 0; index < charCount; ++index)
            {
                char key = chars[index + charIndex];
                byte num;
                bool flag = Cp1250Encoding.charToByte.TryGetValue(key, out num);
                bytes[byteIndex + index] = flag ? num : this.FallbackByte.Value;
            }
            return charCount;
        }

        private int GetBytesWithoutFallback(
          char[] chars,
          int charIndex,
          int charCount,
          byte[] bytes,
          int byteIndex)
        {
            for (int index = 0; index < charCount; ++index)
            {
                char key = chars[index + charIndex];
                byte num;
                if (!Cp1250Encoding.charToByte.TryGetValue(key, out num))
                    throw new EncoderFallbackException(string.Format("The encoding [{0}] cannot encode the character [{1}] (int value {2}). Set the FallbackCharacter property in order to suppress this exception and encode a default character instead.", (object)this.WebName, (object)key, (object)(int)key));
                bytes[byteIndex + index] = num;
            }
            return charCount;
        }

        public override int GetChars(
          byte[] bytes,
          int byteIndex,
          int byteCount,
          char[] chars,
          int charIndex)
        {
            return !this.FallbackCharacter.HasValue ? this.GetCharsWithoutFallback(bytes, byteIndex, byteCount, chars, charIndex) : this.GetCharsWithFallback(bytes, byteIndex, byteCount, chars, charIndex);
        }

        private int GetCharsWithFallback(
          byte[] bytes,
          int byteIndex,
          int byteCount,
          char[] chars,
          int charIndex)
        {
            for (int index = 0; index < byteCount; ++index)
            {
                byte num = bytes[index + byteIndex];
                char ch = (int)num >= Cp1250Encoding.byteToChar.Length ? this.FallbackCharacter.Value : Cp1250Encoding.byteToChar[(int)num];
                chars[charIndex + index] = ch;
            }
            return byteCount;
        }

        private int GetCharsWithoutFallback(
          byte[] bytes,
          int byteIndex,
          int byteCount,
          char[] chars,
          int charIndex)
        {
            for (int index = 0; index < byteCount; ++index)
            {
                byte num = bytes[index + byteIndex];
                if ((int)num >= Cp1250Encoding.byteToChar.Length)
                    throw new EncoderFallbackException(string.Format("The encoding [{0}] cannot decode byte value [{1}]. Set the FallbackCharacter property in order to suppress this exception and decode the value as a default character instead.", (object)this.WebName, (object)num));
                chars[charIndex + index] = Cp1250Encoding.byteToChar[(int)num];
            }
            return byteCount;
        }

        public override int GetByteCount(char[] chars, int index, int count) => count;

        public override int GetCharCount(byte[] bytes, int index, int count) => count;

        public override int GetMaxByteCount(int charCount) => charCount;

        public override int GetMaxCharCount(int byteCount) => byteCount;

        public static int CharacterCount => Cp1250Encoding.byteToChar.Length;
    }
}