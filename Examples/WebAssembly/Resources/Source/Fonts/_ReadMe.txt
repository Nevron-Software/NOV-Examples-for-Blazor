1. Fonts take a lot of space when embedded as NOV resources. This slows down build time a lot because multiple large CS files should be compiled every time the project is built.
2. Compressing the fonts in ZIP archives saves time, but slows down their loading multiple times due to the decompression. For example loading all fonts in this folder when embedded as an uncompressed resources takes 16ms in Release and loading them from a ZIP compressed resource takes about 130ms in releas (i.e. 8 times slower).

Because of the above reasons currently only the fonts "Arial" and "SymbolNeu" are embedded uncompressed in Nov.Peresentation. If we find a better ZIP compression library, we can consider embedding the other fonts, too and compressing all fonts in a single ZIP archive that can be loaded like this in NApplication:

/// <summary>
/// Gets the installed fonts.
/// </summary>
/// <returns></returns>
internal virtual NList<NOTPhysicalFont> GetInstalledFonts()
{
	// Load the fonts embedded as resources
	NList<NOTPhysicalFont> fonts;
	byte[] fontData = NResources.RFONT_Fonts_zip.Data;

	using (MemoryStream ms = new MemoryStream(fontData))
	{
		fonts = NFontsDecompressor.GetInstalledFonts(ms);
	}

	return fonts;
}